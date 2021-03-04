using System;
using System.Threading.Tasks;
using FindDoc.Common.Auth;
using FindDoc.Common.Dtos.UserDto;
using FindDoc.Common.Exceptions.AuthExceptions;
using FindDoc.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FinddocBE.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("registerPatient")]
        public async Task<ActionResult<AuthResponse>> RegisterPatientAsync(RegisterModel model)
        {
            try
            {
                return Ok(await _authService.RegisterPatientAsync(model));
            }catch(RegisterFailedException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("registerDoctor")]
        public async Task<ActionResult<AuthResponse>> RegisterDoctorAsync(RegisterModel model)
        {
            try
            {
                return Ok(await _authService.RegisterDoctorAsync(model));
            }catch(RegisterFailedException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> LoginUserAsync(LoginModel model)
        {
            try
            {
                return Ok(await _authService.LoginUserAsync(model));
            }
            catch (LoginFailedException)
            {
                return Unauthorized();
            }
        }
    }
}
