using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Entities;
using BackEndStructuer.Interface;
using Microsoft.EntityFrameworkCore;

namespace BackEndStructuer.Repository;

public class FeatureRepository : GenericRepository<Feature , int> , IFeatureRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public FeatureRepository(DataContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ICollection<Feature>> GetFeaturesByIds(List<int> featureIds)
    {
        return await _context.Features
            .Where(f => featureIds.Contains(f.Id))
            .ToListAsync();
    }
}