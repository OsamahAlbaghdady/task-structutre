using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository;

public class CategoryRepository : GenericRepository<Category , int> , ICategoryRepository
{
    public CategoryRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}