using AutoMapper;
using BackEndStructuer.DATA.DTOs.RatingStorage;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;

namespace BackEndStructuer.Services;


public interface IRatingStorageService
{
    Task<(RatingStorage? rate, string? error)> Add(Guid userId , int storageId ,RatingStorageForm ratingStorageForm);
    
    Task<(List<RatingStorageDto> rates, int? totalCount, string? error )> GetAll(RatingStorageFilter filter);

    Task<(RatingStorage rate , string? error)> Update(Guid id , RatingStorageUpdate ratingStorage);

    Task<(RatingStorage rate, string? error)> Delete(Guid id);
}

public class RatingStorageService : IRatingStorageService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RatingStorageService(IMapper mapper , IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<(RatingStorage? rate, string? error)> Add(Guid userId , int storageId, RatingStorageForm ratingStorageForm)
    {
        var storage = await _repositoryWrapper.Storage.GetById(storageId);
        if (storage is null) return (null , "Storage not found");
        
        var rating = await _repositoryWrapper.RatingStorage.Get(x => !(x.StorageId == storageId && x.UserId == userId));
        if (rating is null) return (null , "You are already rating this storage");

        rating = _mapper.Map<RatingStorage>(rating);
        rating.StorageId = storageId;
        rating.UserId = userId;

        var response = await _repositoryWrapper.RatingStorage.Add(rating);
        return response == null ? (null , "Rating couldn't update") : (rating , null);
        
    }

    public async Task<(List<RatingStorageDto> rates, int? totalCount, string? error)> GetAll(RatingStorageFilter filter)
    {
        var ratings = await _repositoryWrapper.RatingStorage.GetAll<RatingStorageDto>(x => (
                (filter.Comment == null || x.Comment.Contains(filter.Comment)) &&
                (filter.StorageId == null || x.StorageId == filter.StorageId) &&
                (filter.Stars == null || x.Stars == filter.Stars)
                ),
            filter.PageNumber , filter.PageSize
            );
        
        return (ratings.data , ratings.totalCount , null);
    }

    public async Task<(RatingStorage rate, string? error)> Update(Guid id, RatingStorageUpdate ratingStorage)
    {
        var rate = await _repositoryWrapper.RatingStorage.GetById(id);
        if (rate is null) return (null , "Rate not found") ;

        var rateToUpdate = _mapper.Map(ratingStorage , rate);
        var response = await _repositoryWrapper.RatingStorage.Update(rateToUpdate);
        return response == null ? (null , "Rate couldn't update"):(rate , null );
    }

    public async Task<(RatingStorage rate, string? error)> Delete(Guid id)
    {
        var rate = await _repositoryWrapper.RatingStorage.GetById(id);
        if (rate is null) return (null , "Rate not found") ;

        var response = await _repositoryWrapper.RatingStorage.Delete(id);

        return response == null ? (null ,"Rate couldn't delete") : (rate , null);
    }
}