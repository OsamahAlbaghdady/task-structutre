using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository;

public class StorageFileRepository : GenericRepository<StorageFile, int> , IStorageFileRepository
{
    public StorageFileRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}