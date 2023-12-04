using AutoMapper;
using BackEndStructuer.DATA.DTOs.Category;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using NewEppBackEnd.Services;

namespace BackEndStructuer.Services;


public interface IFeatureService
{
   Task<(FeatureDto?, string? error)> add(FeatureForm featureForm , IFormFile Image );
   Task<(List<FeatureDto> features, int? totalCount, string? error)> GetAll(FeatureFilter filter);
   Task<(FeatureDto? feature, string? error)> update(FeatureFormUpdate featureUpdate , int id);
   Task<(FeatureDto? feature, string? error)> delete(int id);
}

public class FeatureService : IFeatureService
{
   private readonly IMapper _mapper;
   private readonly IRepositoryWrapper _repositoryWrapper;
   private readonly IFileService _fileService;

   public FeatureService(
      IMapper mapper ,
      IRepositoryWrapper repositoryWrapper,
      IFileService fileService
      )
   {
      _mapper = mapper;
      _repositoryWrapper = repositoryWrapper;
      _fileService = fileService;
   }
   
   
   public async Task<(FeatureDto?, string? error)> add(FeatureForm featureForm , IFormFile Image )
   {
      var image =  _fileService.Upload(Image);
      if (image == null) return (null , "can't upload this file");
      var feature = _mapper.Map<Feature>(featureForm);
      feature.Image = image.Result.file.Path;
      var result = await _repositoryWrapper.Feature.Add(feature);
      var map = _mapper.Map<FeatureDto>(feature);
      return result == null ? (null , "feature couldn't add") : (map , null);
   }

   public async Task<(List<FeatureDto> features, int? totalCount, string? error)> GetAll(FeatureFilter filter)
   {
      var (features, totalCount) = await _repositoryWrapper.Feature.GetAll<FeatureDto>( 
         x=> (filter.Name == null || x.Name.Contains(filter.Name))
         , filter.PageNumber);
      return (features, totalCount, null);
   }

   public async Task<(FeatureDto? feature, string? error)> update(FeatureFormUpdate featureUpdate, int id)
   {
      var feature = await _repositoryWrapper.Feature.GetById(id);
      if (feature == null) return (null, "feature not found "); 
      feature = _mapper.Map(featureUpdate , feature);
      var response = await _repositoryWrapper.Feature.Update(feature);
      var map = _mapper.Map<FeatureDto>(feature);
      return response == null ? (null , "feature couldn't update") : (map , null);
   }

   public async Task<(FeatureDto? feature, string? error)> delete(int id)
   {
      var feature = await _repositoryWrapper.Feature.GetById(id);
      if (feature == null) return (null, "feature not found ");
      var result = await _repositoryWrapper.Feature.Delete(id);
      var map = _mapper.Map<FeatureDto>(feature);
      return result == null ? (null, "feature could not be deleted") : (map, null);
   }
}