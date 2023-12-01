using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository;

public class StorageRepository : GenericRepository<Storage, int>, IStorageRepository 
{
    public StorageRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}