using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class JwtTokenService(IConfiguration configuration, IHttpContextAccessor httpcontextAccessor)
{
    private readonly IHttpContextAccessor _httpcontextAccessor = httpcontextAccessor;
    private readonly IConfiguration _configuration = configuration;

    public string GenerateToken(Guid userId, string name, string role)
    {
        var claims = new List<Claim>
        {
            new(IdentityData.NameClaim, name),
            new(IdentityData.RoleClaim, role),
            new("UserID", userId.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var secret = _configuration["JWT:Secret"] ?? throw new Exception("Missing JWT Secret");
        var expireIn = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JWT:ExpirationInHours"]));
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: expireIn,
            claims: claims,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            notBefore: DateTime.UtcNow.AddSeconds(1)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public string GetRoleFromToken()
    {
        var userIdClaim = _httpcontextAccessor.HttpContext?.User.FindFirst("Role");
        if (userIdClaim == null)
        {
            throw new Exception("Role not found in token");
        }
        return userIdClaim.Value ?? throw new Exception("Role not found in token");
    }
    public string GetUserIdFromToken()
    {
        var userIdClaim = _httpcontextAccessor.HttpContext?.User.FindFirst("UserID");
        if (userIdClaim == null)
        {
            throw new Exception("User ID not found in token");
        }
        return userIdClaim.Value ?? throw new Exception("User ID not found in token");
    }   
}
