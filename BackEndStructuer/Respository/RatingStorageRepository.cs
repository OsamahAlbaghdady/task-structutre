using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository;

public class RatingStorageRepository : GenericRepository<RatingStorage , Guid> , IRatingStorageRepository
{
    public RatingStorageRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}