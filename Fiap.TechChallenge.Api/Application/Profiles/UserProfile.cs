using AutoMapper;
using Fiap.TechChallenge.Api.Application.Dtos.User;
using Microsoft.AspNetCore.Identity;

namespace Fiap.TechChallenge.Api.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserInputDto, IdentityUser>();
        CreateMap<IdentityUser, UserAuthorizedDto>();
    }
}