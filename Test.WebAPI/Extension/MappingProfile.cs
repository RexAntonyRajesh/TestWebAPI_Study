using AutoMapper;
using Test.Domain;
using Test.Service;

namespace TestAPI.Extension
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}
