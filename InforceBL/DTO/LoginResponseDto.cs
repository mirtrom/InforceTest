namespace InforceBL.DTO
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
