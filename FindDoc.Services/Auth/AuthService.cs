using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FindDoc.Common.Auth;
using FindDoc.Common.Dtos.UserDto;
using FindDoc.Common.Exceptions.AuthExceptions;
using FindDoc.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FindDoc.Services.Auth
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWTConfig _jwtTokenConfig;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            JWTConfig JWTConfig
        ) {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenConfig = JWTConfig;
        }

        public async Task<AuthResponse> LoginUserAsync(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRole = (await _userManager.GetRolesAsync(user)).First();

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, userRole)
                };

                var authSigningKey = _jwtTokenConfig.GetSymmetricSecurityKey(_jwtTokenConfig.Secret);

                var jwtToken = new JwtSecurityToken(
                  _jwtTokenConfig.Issuer,
                  _jwtTokenConfig.Audience,
                  authClaims,
                  expires: DateTime.Now.AddMinutes(_jwtTokenConfig.AccessTokenExpiration),
                  signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
                  );

                return new AuthResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    Expiration = jwtToken.ValidTo,
                    User = new UserDto
                    {
                        Email = user.Email,
                        Name = user.UserName,
                        Id = user.Id,
                        Role = userRole
                    }
                };
            }

            throw new LoginFailedException();
        }

        public async Task<AuthResponse> RegisterPatientAsync(RegisterModel model)
        {
            return await RegisterEntity(model, UserRoles.Patient);
        }

        public async Task<AuthResponse> RegisterDoctorAsync(RegisterModel model)
        {
            return await RegisterEntity(model, UserRoles.Doctor);
        }

        private async Task<AuthResponse> RegisterEntity(RegisterModel model, string role)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                throw new RegisterFailedException("User already exists!");

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new RegisterFailedException("User creation failed! Please check user details and try again.");

            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
                await _userManager.AddToRoleAsync(user, role);

            //Map to dto
            return new AuthResponse
            {
                User = new UserDto
                {
                    Email = user.Email,
                    Name = user.NormalizedUserName,
                    Id = user.Id,
                    Role = role
                }
            };
        }
    }
}