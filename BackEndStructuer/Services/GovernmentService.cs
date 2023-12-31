﻿using AutoMapper;
using BackEndStructuer.DATA.DTOs.Category;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using NewEppBackEnd.Services;

namespace BackEndStructuer.Services;


public interface IGovernmentService
{
   Task<(Government?, string? error)> add(GovernmentForm governmentForm );
   Task<(List<GovernmentDto> governments, int? totalCount, string? error)> GetAll(GovernmentFilter filter);
   Task<(Government? government, string? error)> update(GovernmentFormUpdate governmentUpdate , int id);
   Task<(Government? government, string? error)> delete(int id);
}

public class GovernmentService : IGovernmentService
{
   private readonly IMapper _mapper;
   private readonly IRepositoryWrapper _repositoryWrapper;
   private readonly IFileService _fileService;

   public GovernmentService(
      IMapper mapper ,
      IRepositoryWrapper repositoryWrapper,
      IFileService fileService
      )
   {
      _mapper = mapper;
      _repositoryWrapper = repositoryWrapper;
      _fileService = fileService;
   }
   
   
   public async Task<(Government?, string? error)> add(GovernmentForm governmentForm )
   {
      var government = _mapper.Map<Government>(governmentForm);
      var result = await _repositoryWrapper.Government.Add(government);
      return result == null ? (null , "government couldn't add") : (result , null);
   }

   public async Task<(List<GovernmentDto> governments, int? totalCount, string? error)> GetAll(GovernmentFilter filter)
   {
      var (governments, totalCount) = await _repositoryWrapper.Government.GetAll<GovernmentDto>(
         x=> (filter.Name == null || x.Name.Contains(filter.Name)),
         filter.PageNumber , filter.PageSize
         );
      return (governments, totalCount, null);
   }

   public async Task<(Government? government, string? error)> update(GovernmentFormUpdate governmentUpdate, int id)
   {
      var government = await _repositoryWrapper.Government.GetById(id);
      if (government == null) return (null, "government not found "); 
      government = _mapper.Map(governmentUpdate , government);
      var response = await _repositoryWrapper.Government.Update(government);
      return response == null ? (null , "government couldn't update") : (government , null);
   }

   public async Task<(Government? government, string? error)> delete(int id)
   {
      var government = await _repositoryWrapper.Government.GetById(id);
      if (government == null) return (null, "government not found ");
      var result = await _repositoryWrapper.Government.Delete(id);
      return result == null ? (null, "government could not be deleted") : (government, null);
   }
}