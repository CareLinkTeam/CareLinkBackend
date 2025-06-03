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


        [HttpPut("UpdateUser")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserDto user)
        {
            var response = new BaseHttpResponse<Users>();

            try
            {
                var updatedUser = await _userService.UpdateUser(user);
                response.SetSuccess(updatedUser, "User updated successfully.", "200");
                return Ok(response);
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

        [HttpGet("GetUserDetails")]
        [Authorize]
        public async Task<IActionResult> GetUserDetails(string username)
        {
            var response = new BaseHttpResponse<Users>();

            try
            {
                var user = await _userService.GetUserByUsername(username);
                response.SetSuccess(user, "User retrieved successfully.", "200");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new ErrorData
                {
                    Code = "1-GetUserDetails",
                    Message = ex.Message
                };
                _logger.LogError(ex, "Error updating user");
                return BadRequest(error);
            }
        }

        [HttpDelete("DeleteUser")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var response = new BaseHttpResponse<string>();

            try
            {
                var user = await _userService.DeleteUser(username);
                response.SetSuccess(user, "User deleted successfully.", "200");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new ErrorData
                {
                    Code = "1-DeleteUser",
                    Message = ex.Message
                };
                _logger.LogError(ex, "Error updating user");
                return BadRequest(error);
            }
        }



    }
}
