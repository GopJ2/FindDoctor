using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FindDoc.Common.Auth;
using FindDoc.Common.Dtos.UserDto;
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

        public async Task<AuthResponse> LoginUserAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
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
                    },
                    Status = 200,
                };
            }

            return new AuthResponse
            {
                Status = 200,
                Message = "Provided credentials are incorrect"
            };
        }

        public async Task<AuthResponse> RegisterPatientAsync(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return new AuthResponse { Status = 200, Message = "User already exists!" };

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) {
                return new AuthResponse { Status = 200, Message = "User creation failed! Please check user details and try again." };
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Patient))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Patient));

            if (await _roleManager.RoleExistsAsync(UserRoles.Patient))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Patient);
            }

            return new AuthResponse { Status = 200, Message = "User created successfully!" };
        }

        public async Task<AuthResponse> RegisterDoctorAsync(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return new AuthResponse { Status = 200, Message = "User already exists!" };

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new AuthResponse { Status = 200, Message = "User creation failed! Please check user details and try again." };

            if (!await _roleManager.RoleExistsAsync(UserRoles.Doctor))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Doctor));
            
            if (await _roleManager.RoleExistsAsync(UserRoles.Doctor))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Doctor);
            }

            return new AuthResponse { Status = 200, Message = "User created successfully!" };
        }
    }
}