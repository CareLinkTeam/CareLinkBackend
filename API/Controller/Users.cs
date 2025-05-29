using Application.DTOs;
using Application.Interface;
using Domain;
using Microsoft.AspNetCore.Mvc;


namespace API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(ILogger<UsersController> logger, IUsersService userService) : ControllerBase
    {
        private readonly ILogger<UsersController> _logger = logger;
        private readonly IUsersService _userService = userService;

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUsers(CreateUserDto user)
        {
            var response = new BaseHttpResponse<Users>();

            try
            {
                Console.WriteLine("Creating user with username: " + user.UserName);
                var createdUser = await _userService.CreateUser(user);
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



    }
}
