using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository
{
    public class PermissionRepository : GenericRepository<Permission,int>, IPermissionRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PermissionRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}