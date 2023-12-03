using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository;

public class BookMarkRepository : GenericRepository<Bookmark , int> , IBookMarkRepository
{
    public BookMarkRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}