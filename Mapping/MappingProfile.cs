using AutoMapper;
using SkillSwap.Dtos.User;
using SkillSwap.Models;

namespace SkillSwap.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserPostDTO, User>();
        CreateMap<UserPutAdminDTO, User>();
    }

}