using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository;

public class ReservedStorageRepository : GenericRepository<ReservedStorage , Guid> , IReservedStorage
{
    public ReservedStorageRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}