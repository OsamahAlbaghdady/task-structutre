using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.ArticleDto;
using BackEndStructuer.DATA.DTOs.roles;
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
            CreateMap<AppUser, AppUser>();
            CreateMap<Permission, PermissionDto>();

        }
    }
}