namespace BackEndStructuer.Entities
{
    public class Permission : BaseEntity<int>
    {
        public string PermissionName { get; set; } 
        public List<RolePermission> RolePermissions { get; set; }
    }
    
    public class PermissionDto : BaseEntity<int>
    {
        public string PermissionName { get; set; } 
    }
}