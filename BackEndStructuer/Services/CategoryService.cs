using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BackEndStructuer.DATA.DTOs.Category;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using NewEppBackEnd.Services;

namespace BackEndStructuer.Services;


public interface ICategoryService
{
   Task<(Category?, string? error)> add(CategoryForm categoryForm );
   Task<(List<CategoryDto> categories, int? totalCount, string? error)> GetAll(CategoryFilter filter);
   Task<(Category? category, string? error)> update(CategoryFormUpdate categoryUpdate , int id);
   Task<(Category? category, string? error)> delete(int id);
}

public class CategoryService : ICategoryService
{
   private readonly IMapper _mapper;
   private readonly IRepositoryWrapper _repositoryWrapper;
   private readonly IFileService _fileService;

   public CategoryService(
      IMapper mapper ,
      IRepositoryWrapper repositoryWrapper,
      IFileService fileService
      )
   {
      _mapper = mapper;
      _repositoryWrapper = repositoryWrapper;
      _fileService = fileService;
   }
   
   
   public async Task<(Category?, string? error)> add(CategoryForm categoryForm )
   {
      var category = _mapper.Map<Category>(categoryForm);
      var result = await _repositoryWrapper.Category.Add(category);
      return result == null ? (null , "category couldn't add") : (result , null);
   }

   public async Task<(List<CategoryDto> categories, int? totalCount, string? error)> GetAll(CategoryFilter filter)
   {
      var (categories, totalCount) = await _repositoryWrapper.Category.GetAll<CategoryDto>( x=> (
         filter.Name == null || x.Name.Contains(filter.Name)
         ),filter.PageNumber , filter.PageSize);
      return (categories, totalCount, null);
   }

   public async Task<(Category? category, string? error)> update(CategoryFormUpdate categoryUpdate, int id)
   {
      var category = await _repositoryWrapper.Category.GetById(id);
      if (category == null) return (null, "category not found "); 
      category = _mapper.Map(categoryUpdate , category);
      var response = await _repositoryWrapper.Category.Update(category);
      return response == null ? (null , "category couldn't update") : (response , null);
   }

   public async Task<(Category? category, string? error)> delete(int id)
   {
      var category = await _repositoryWrapper.Category.GetById(id);
      if (category == null) return (null, "category not found ");
      var result = await _repositoryWrapper.Category.Delete(id);
      return result == null ? (null, "category could not be deleted") : (result, null);
   }
}