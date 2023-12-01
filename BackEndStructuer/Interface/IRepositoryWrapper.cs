using BackEndStructuer.Interface;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository
{
    public interface IRepositoryWrapper
    {
   
        IUserRepository User { get; }
        IArticleRespository Article { get; }
        IPermissionRepository Permission { get; }
        
        IRoleRepository Role { get; }
        
    }
}