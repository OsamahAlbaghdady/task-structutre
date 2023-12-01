using BackEndStructuer.Entities;

namespace BackEndStructuer.Interface;

public interface IFeatureRepository : IGenericRepository<Feature , int>
{
    Task<ICollection<Feature>> GetFeaturesByIds(List<int> featureIds);
}