using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.Storage;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Utils;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using NewEppBackEnd.Services;
using OneSignalApi.Model;

namespace BackEndStructuer.Services;


public interface IStorageService
{
   Task<(Storage?, string? error)> add(Guid Id , StorageForm storageForm );
   Task<(List<StorageDto> storages, int? totalCount, string? error)> GetAll(string role, StorageFilter filter , Guid Id, int _pageNumber = 0);
   Task<(Storage? storage, string? error)> update(StorageFormUpdate storageUpdate , int id);
   Task<(Storage? storage, string? error)> delete(int id);
}

public class StorageService : IStorageService
{
   private readonly IMapper _mapper;
   private readonly IRepositoryWrapper _repositoryWrapper;
   private readonly IFileService _fileService;

    public StorageService(
      IMapper mapper ,
      IRepositoryWrapper repositoryWrapper,
      IFileService fileService, 
      DataContext dataContext
      )
   {
      _mapper = mapper;
      _repositoryWrapper = repositoryWrapper;
      _fileService = fileService;
   }
   
   
   public async Task<(Storage?, string? error)> add(Guid Id , StorageForm storageForm )
   {
      var government = await _repositoryWrapper.Government.GetById(storageForm.GovernmentId);
      if (government == null) return (null, "Government not found");
      
      var category = await _repositoryWrapper.Category.GetById(storageForm.CategoryId);
      if (category == null) return (null, "Category not found");

      var features = await _repositoryWrapper.Feature.GetFeaturesByIds(storageForm.FeatureIds);
      if (features.Count < storageForm.FeatureIds.Count) return (null , "One of some features not found");

      var storage = _mapper.Map<Storage>(storageForm);
      storage.Features = features;
      storage.UserId = Id;
      foreach (var file in storageForm.Files)
      {
         storage.Files.Add(new StorageFile(file));
      }
      
      var result = await _repositoryWrapper.Storage.Add(storage);
      return result == null ? (null , "storage couldn't add") : (storage , null);
   }
   
 

   public async Task<(List<StorageDto> storages, int? totalCount, string? error)> GetAll(string role , StorageFilter filter , Guid Id , int _pageNumber = 0)
   {
      var storages = await _repositoryWrapper.Storage.GetAll(x => (
         (filter.Name == null || x.Name.Contains(filter.Name)) && 
         (filter.Description == null || x.Description.Contains(filter.Description)) &&
         (filter.CategoryId == null || x.CategoryId == filter.CategoryId) && 
         (filter.GovernmentId == null || filter.GovernmentId == x.GovernmentId) &&
         (filter.MinPrice == null || filter.MaxPrice == null || (x.Price >= filter.MinPrice && x.Price <= filter.MaxPrice)) &&
         (filter.IsReserved == null || x.IsReserved == filter.IsReserved) &&
         (filter.NumberOrRoom == null || x.NumberOfRom == filter.NumberOrRoom) && 
         (filter.Features == null || x.Features.Any(f=> filter.Features.Contains(f.Id) )) &&
         (filter.Lat == null  || filter.Lng == null  || filter.Distance == null  || (Math.Abs((double)(x.Lat - filter.Lat)) < (filter.Distance / 111) && Math.Abs((double)(x.Lng - filter.Lng)) < (filter.Distance / (111 * Math.Cos(DegreesToRadians(filter.Lat.Value)))))) &&
         (filter.IsOwner == null || x.UserId == Id) && 
         (filter.IsInReserved == null || x.ReservedStorages.Any((u => u.Id == Id)))
      ) , i => i.Include(f => f.Files)  ,filter.PageNumber , filter.PageSize);
    
      var map = _mapper.Map<List<StorageDto>>(storages.data).OrderByDescending(s => s.CreationDate);
      
      return (map.ToList() , storages.totalCount  , null);
   }
   public async Task<(Storage? storage, string? error)> update(StorageFormUpdate storageUpdate, int id)
   {
      var storage = await _repositoryWrapper.Storage.GetById(id);
      if (storage == null) return (null, "storage not found "); 
      storage = _mapper.Map(storageUpdate , storage);
      var response = await _repositoryWrapper.Storage.Update(storage);
      return response == null ? (null , "storage couldn't update") : (response , null);
   }

   public async Task<(Storage? storage, string? error)> delete(int id)
   {
      var storage = await _repositoryWrapper.Storage.GetById(id);
      if (storage == null) return (null, "storage not found ");
      var result = await _repositoryWrapper.Storage.Delete(id);
      return result == null ? (null, "storage could not be deleted") : (result, null);
   }
   
   private double DegreesToRadians(double degrees)
   {
      return degrees * (Math.PI / 180);
   }
   
}