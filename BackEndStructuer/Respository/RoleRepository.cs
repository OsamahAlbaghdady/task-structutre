using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Interface;
using Role = BackEndStructuer.Entities.Role;

namespace BackEndStructuer.Repository
{
    public class RoleRepository : GenericRepository<Role,int>, IRoleRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(DataContext context, IMapper mapper) : base(context,mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}