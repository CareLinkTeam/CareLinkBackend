namespace Application.DTOs
{
    public class CreateUserDto
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
    }
    public class LoginResponse
    {
        public string Token { get; set; } = null!;
    }

}