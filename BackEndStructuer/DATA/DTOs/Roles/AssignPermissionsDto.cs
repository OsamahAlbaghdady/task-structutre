namespace BackEndStructuer.DATA.DTOs.roles
{
    public class AssignPermissionsDto
    {
        public List<string> Permissions { get; set; }
    }
    
    
    public class MyPermissionsListDto
    {
        public List<MyPermissionsDto> Data { get; set; }
    }
    
    public class MyPermissionsDto
    {
    
        public string Subject { get; set; }
        public IEnumerable<string> Actions { get; set; }
    }
}