using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BackEndStructuer.DATA.DTOs.Storage;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using NewEppBackEnd.Services;

namespace BackEndStructuer.Services;


public interface IStorageService
{
   Task<(Storage?, string? error)> add(StorageForm storageForm );
   Task<(List<StorageDto> storages, int? totalCount, string? error)> GetAll(int _pageNumber = 0);
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
      IFileService fileService
      )
   {
      _mapper = mapper;
      _repositoryWrapper = repositoryWrapper;
      _fileService = fileService;
   }
   
   
   public async Task<(Storage?, string? error)> add(StorageForm storageForm )
   {
      var government = await _repositoryWrapper.Government.GetById(storageForm.GovernmentId);
      if (government == null) return (null, "Government not found");
      
      var category = await _repositoryWrapper.Category.GetById(storageForm.CategoryId);
      if (category == null) return (null, "Category not found");

      var features = await _repositoryWrapper.Feature.GetFeaturesByIds(storageForm.FeatureIds);
      if (features.Count < storageForm.FeatureIds.Count) return (null , "One of some features not found");


      var files = await _fileService.Upload(storageForm.Files);
      if (files.files.Count == null) return (null , "can't upload files");

      var storage = _mapper.Map<Storage>(storageForm);
      storage.Category = category;
      storage.Government = government;
      storage.Features = features;
      foreach (var file in files.files)
      {
         var storageFile = new StorageFile(file.Path);
         storage.Files.Add(storageFile);  
      }
      var result = await _repositoryWrapper.Storage.Add(storage);
      return result == null ? (null , "storage couldn't add") : (storage , null);
   }

   public async Task<(List<StorageDto> storages, int? totalCount, string? error)> GetAll(int _pageNumber = 0)
   {
      var (storages, totalCount) = await _repositoryWrapper.Storage.GetAll<StorageDto>(_pageNumber);
      return (storages, totalCount, null);
   }

   public async Task<(Storage? storage, string? error)> update(StorageFormUpdate storageUpdate, int id)
   {
      var storage = await _repositoryWrapper.Storage.GetById(id);
      if (storage == null) return (null, "storage not found "); 
      storage = _mapper.Map(storageUpdate , storage);
      var response = await _repositoryWrapper.Storage.Update(storage);
      return response == null ? (null , "storage couldn't update") : (storage , null);
   }

   public async Task<(Storage? storage, string? error)> delete(int id)
   {
      var storage = await _repositoryWrapper.Storage.GetById(id);
      if (storage == null) return (null, "storage not found ");
      var result = await _repositoryWrapper.Storage.Delete(id);
      return result == null ? (null, "storage could not be deleted") : (result, null);
   }
}