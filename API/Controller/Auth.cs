using Application.DTOs;
using Application.Interface;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controller
{

    // [Authorize(Policy = IdentityData.AdminPolicy)]
    // [Authorize(Policy = IdentityData.CareTakerPolicy)]
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(ILogger<AuthController> logger, IUsersService userService) : ControllerBase
    {
        private readonly ILogger<AuthController> _logger = logger;
        private readonly IUsersService _userService = userService;


        [HttpPost("SignUpCustomer")]
        public async Task<IActionResult> SignUpCustomer([FromBody] CreateUserDto user)
        {
            var response = new BaseHttpResponse<string>();

            try
            {
                var token = await _userService.SignUpCustomer(user);

                response.SetSuccess(token, "User created successfully.", "201");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new ErrorData
                {
                    Code = "1-SignUpCustomer",
                    Message = ex.Message
                };
                _logger.LogError(ex, "Error creating user");
                return BadRequest(error);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto req)
        {
            var response = new BaseHttpResponse<string>();

            try
            {
                var token = await _userService.Login(req.UserName, req.Password);
                response.SetSuccess(token, "Login successful.", "200");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new ErrorData
                {
                    Code = "1-Login",
                    Message = ex.Message
                };
                _logger.LogError(ex, "Error logging in user");
                return BadRequest(error);
            }
        }

    }
}
