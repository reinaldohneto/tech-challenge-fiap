using AutoMapper;
using Fiap.TechChallenge.Api.Application.Dtos.User;
using Fiap.TechChallenge.Api.Application.Services.Authentication;
using Fiap.TechChallenge.Api.Application.Shared;
using Fiap.TechChallenge.Api.Application.Validators;
using Microsoft.AspNetCore.Identity;

namespace Fiap.TechChallenge.Api.Application.Services.User;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly NotificationContext _notificationContext;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public UserService(UserManager<IdentityUser> userManager, NotificationContext notificationContext, 
        IMapper mapper, IAuthenticationService authenticationService)
    {
        _userManager = userManager;
        _notificationContext = notificationContext;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }


    public async Task<UserAuthorizedDto?> CreateAsync(UserInputDto user)
    {
        user.Validate(new UserInputDtoValidator());

        if (user.Invalid)
        {
            _notificationContext.AddNotifications(user.ValidationResult);
            return null;
        }

        var userDomain = _mapper.Map<IdentityUser>(user);

        var result = await _userManager.CreateAsync(userDomain);
        await _userManager.AddPasswordAsync(userDomain, user.Password);

        if (result.Succeeded)
            return await _authenticationService.GenerateAuthorizedToken(userDomain.UserName!, user.Password);

        return null;
    }

    public async Task<UserAuthorizedDto?> LoginAsync(UserLoginDto login)
        => await _authenticationService.GenerateAuthorizedToken(login.UserName, login.Password);
}