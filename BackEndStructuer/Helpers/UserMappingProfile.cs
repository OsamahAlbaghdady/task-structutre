using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.ArticleDto;
using BackEndStructuer.DATA.DTOs.Category;
using BackEndStructuer.DATA.DTOs.RatingStorage;
using BackEndStructuer.DATA.DTOs.ReservedStorage;
using BackEndStructuer.DATA.DTOs.roles;
using BackEndStructuer.DATA.DTOs.Storage;
using BackEndStructuer.DATA.DTOs.User;
using BackEndStructuer.Entities;
using OneSignalApi.Model;


namespace BackEndStructuer.Helpers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<ArticleForm,Article>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ArticleUpdate,Article>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AppUser, UserDto>()
            .ForMember(r => r.Role , src => src.MapFrom(src => src.Role.Name));
            CreateMap<RegisterForm,App>().ForAllMembers( opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Role, RoleDto>();
            CreateMap<Article, ArticleDto>();
            CreateMap<Permission, PermissionDto>();
            
            
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForm, Category>();
            CreateMap<CategoryFormUpdate, Category>();

            
            CreateMap<Feature, FeatureDto>();
            CreateMap<FeatureForm, Feature>();
            CreateMap<FeatureFormUpdate, Feature>();

            
            CreateMap<Government, GovernmentDto>();
            CreateMap<GovernmentForm, Government>();
            CreateMap<GovernmentFormUpdate, Government>();

            CreateMap<Storage, StorageDto>();
            CreateMap<StorageForm, Storage>().ForMember(dist => dist.Files , opt => opt.Ignore());
            CreateMap<StorageFormUpdate, Storage>();


            CreateMap<Bookmark, StorageDto>();

            CreateMap<ReservedStorage , ReservedStorageDto>();
            CreateMap<ReservedStorageUpdate , ReservedStorage>();
            
            
            CreateMap<RatingStorage, RatingStorageDto>();
            CreateMap<RatingStorageForm, RatingStorage>();
            CreateMap<RatingStorageForm, RatingStorage>();
            

        }
    }
}