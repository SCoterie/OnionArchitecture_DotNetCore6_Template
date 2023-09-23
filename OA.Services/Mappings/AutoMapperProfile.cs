using AutoMapper;
using OA.Models.DTO;
using OA.Models.ViewModel;

namespace OA.Services.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User Mapping

            CreateMap<UserSignupViewModel, ApplicationUser>()
                .ForMember(
                    dest => dest.UserName,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => $"{src.Email}")
                )
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => $"{src.FirstName}")
                )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => $"{src.LastName}")
                )
                .ForMember(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src => $"{src.Mobile}")
                )
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => $"{DateTime.UtcNow}")
                )
                .ReverseMap();

            CreateMap<DateTime, ApplicationUser>()
                .ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => $"{src}")
                );
            CreateMap<string, ApplicationUser>()
                .ForMember(
                    dest => dest.CreatedBy,
                    opt => opt.MapFrom(src => $"{src}")
                );
            CreateMap<string, ApplicationUser>()
               .ForMember(
                   dest => dest.UpdatedBy,
                   opt => opt.MapFrom(src => $"{src}")
               );

            // Role Mapping

            CreateMap<string, ApplicationRole>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src}")
                );


        }
    }
}
