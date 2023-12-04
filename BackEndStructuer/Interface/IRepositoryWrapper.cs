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

        ICategoryRepository Category { get; }
        
        IFeatureRepository Feature { get; }
        IGovernmentRepository Government { get; }
        IStorageRepository Storage { get; }
        
        IStorageFileRepository StorageFile { get; }
        
        IBookMarkRepository BookMark { get; }
        
        IReservedStorage ReservedStorage { get; }

        IRatingStorageRepository RatingStorage { get; }

    }
}