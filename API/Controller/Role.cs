using Application.DTOs;
using Application.Interface;
using Application.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController(ILogger<AuthController> logger, IRoleService roleService, JwtTokenService jwtTokenService) : ControllerBase
    {
        private readonly ILogger<AuthController> _logger = logger;
        private readonly IRoleService _roleService = roleService;
        private readonly JwtTokenService _jwtTokenService = jwtTokenService;


        [HttpGet("GetAllRoles")]
        [Authorize]
        public async Task<IActionResult> GetAllRoles()
        {
            var response = new BaseHttpResponse<List<RoleDto>>();

            try
            {
                var roles = await _roleService.GetAllRoles();
                response.SetSuccess(roles, "Roles retrieved successfully.", "200");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new ErrorData
                {
                    Code = "1-GetAllRoles",
                    Message = ex.Message
                };
                _logger.LogError(ex, "Error retrieving roles");
                return BadRequest(error);
            }
        }

        [HttpGet("GetUserRole")]
        [Authorize]
        public async Task<IActionResult> GetUserRole()
        {
            var response = new BaseHttpResponse<string>();

            try
            {
                var userRole = _jwtTokenService.GetUserIdFromToken();
                response.SetSuccess(userRole, "User role retrieved successfully.", "200");
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new ErrorData
                {
                    Code = "1-GetUserRole",
                    Message = ex.Message
                };
                _logger.LogError(ex, "Error retrieving user role");
                return BadRequest(error);
            }
        }
    }
}
