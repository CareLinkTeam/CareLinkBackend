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
    public class UserController(ILogger<AuthController> logger, IUsersService userService) : ControllerBase
    {
        private readonly ILogger<AuthController> _logger = logger;
        private readonly IUsersService _userService = userService;


        [HttpPut("UpdateCustomer")]
        [Authorize]
        public async Task<IActionResult> UpdateCustomer(UserDto user)
        {
            var response = new BaseHttpResponse<Users>();

            try
            {
                var updatedUser = await _userService.UpdateCustomer(user);
                response.SetSuccess(updatedUser, "User updated successfully.", "200");
                return Ok();
            }
            catch (Exception ex)
            {
                var error = new ErrorData
                {
                    Code = "1-UpdateUser",
                    Message = ex.Message
                };
                _logger.LogError(ex, "Error updating user");
                return BadRequest(error);
            }
        }


    }
}
