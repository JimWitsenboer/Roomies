using AutoMapper;
using API.DTOs;
using API.Entities;
using API.Extensions;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
  public AutoMapperProfiles()
  {
    CreateMap<AppUser, MemberDto>()
      .ForMember(d => d.PhotoUrl, o =>
          o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain)!.Url))
      .ForMember(d => d.Age, o =>
          o.MapFrom(s => s.DateOfBirth.CalculateAge()));
    CreateMap<Photo, PhotoDto>();
    CreateMap<MemberUpdateDto, AppUser>();
    CreateMap<RegisterDto, AppUser>();
    CreateMap<string, DateOnly>().ConstructUsing(s => DateOnly.Parse(s));
  }
}
