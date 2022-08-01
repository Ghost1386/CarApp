using System.Reflection.Metadata;
using AutoMapper;
using CarApp.Common.Models;
using CarApp.Common.ViewModels;

namespace CarApp.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserCreateViewModel, User>();
        
        CreateMap<UserEditViewModel, User>();
    }
}