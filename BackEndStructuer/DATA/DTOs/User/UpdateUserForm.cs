namespace BackEndStructuer.DATA.DTOs.User
{
    public class UpdateUserForm
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
        
        public double? Lat { get; set; }
        
        public double? Lng { get; set; }

    }
}