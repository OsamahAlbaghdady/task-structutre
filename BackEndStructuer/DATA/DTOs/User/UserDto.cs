namespace BackEndStructuer.DATA.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        
        public string FullName { get; set; }
        
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        
        public double Lat { get; set; }
        
        public double Lng { get; set; }
    }
}