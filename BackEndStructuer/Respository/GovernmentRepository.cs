using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository;

public class GovernmentRepository : GenericRepository<Government , int> , IGovernmentRepository
{
    public GovernmentRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}