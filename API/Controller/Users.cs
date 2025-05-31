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
    public class UsersController(ILogger<UsersController> logger, IUsersService userService) : ControllerBase
    {
        private readonly ILogger<UsersController> _logger = logger;
        private readonly IUsersService _userService = userService;

        [HttpPost("CreateCustomer")]
        [Authorize] 
        public async Task<IActionResult> CreateCustomer(CreateUserDto user)
        {
            var response = new BaseHttpResponse<Users>();

            try
            {
                var createdUser = await _userService.CreateCustomer(user);
                response.SetSuccess(createdUser, "User created successfully.", "201");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new ErrorData
                {
                    Code = "1-CreateUser",
                    Message = ex.Message
                };
                _logger.LogError(ex, "Error creating user");
                return BadRequest(error);
            }
        }

        [HttpPost("SignUpCustomer")]
        public async Task<IActionResult> SignUpCustomer(CreateUserDto user)
        {
            var response = new BaseHttpResponse<string>();

            try
            {
                var token = await _userService.SignUpCustomer(user);

                response.SetSuccess(token,"User created successfully.", "201");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new ErrorData
                {
                    Code = "1-CreateUser",
                    Message = ex.Message
                };
                _logger.LogError(ex, "Error creating user");
                return BadRequest(error);
            }
        }


    }
}
