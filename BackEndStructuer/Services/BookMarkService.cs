using AutoMapper;
using BackEndStructuer.DATA.DTOs.Storage;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using Microsoft.EntityFrameworkCore;

namespace BackEndStructuer.Services;

public interface IBookMarkService
{
    Task<(StorageDto? storageDto, string? error)> add(Guid userId, int id);
    Task<(List<StorageDto> storages, int? totalCount, string? error)> GetAll(Guid id,int _pageNumber = 0);
    
    Task<(Bookmark? bookmark, string? error)> delete(int id);

}

public class BookMarkService : IBookMarkService
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;

    public BookMarkService(IRepositoryWrapper repositoryWrapper , IMapper mapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }
    
    public async Task<(StorageDto? storageDto, string? error)> add(Guid userId , int id)
    {
        var user = await _repositoryWrapper.User.GetById(userId);
        if (user == null) return (null , "User not found");

        var storage = await _repositoryWrapper.Storage.GetById(id);
        if (storage == null) return (null , "Storage not found");

        var bookMark = await _repositoryWrapper.BookMark.Get(x => x.StorageId == storage.Id && x.AppUserId == userId);

        await _repositoryWrapper.BookMark.Add(new Bookmark { AppUserId = user.Id, StorageId = storage.Id });
        
        
        var response = _mapper.Map<StorageDto>(storage);

        return response == null ? (null, "Bookmark couldn't be add") : (response, null);
    }

    public async Task<(List<StorageDto> storages, int? totalCount, string? error)> GetAll(Guid id , int _pageNumber = 0)
    {
        var storages = await _repositoryWrapper.BookMark.GetAll(x => x.AppUserId == id , i=>i.Include(s=>s.Storage).Include(s=>s.Storage).ThenInclude(g=>g.Government));

        var map = _mapper.Map<List<StorageDto>>(storages.data.Select(s=>s.Storage));
        return (map, storages.totalCount, null);
    }

    public async Task<(Bookmark? bookmark, string? error)> delete(int id)
    {
        var storage = await _repositoryWrapper.BookMark.GetById(id);
        if (storage == null) return (null, "storage not found ");
        var result = await _repositoryWrapper.BookMark.Delete(id);
        return result == null ? (null, "storage could not be deleted") : (result, null);
    }
}