using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Fiap.TechChallenge.Api.Application.Dtos.User;
using Fiap.TechChallenge.Api.Application.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Fiap.TechChallenge.Api.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IConfiguration _config;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly NotificationContext _notificationContext;

    public AuthenticationService(IConfiguration config, UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager, NotificationContext notificationContext)
    {
        _config = config;
        _userManager = userManager;
        _signInManager = signInManager;
        _notificationContext = notificationContext;
    }

    private string? GenerateToken(IdentityUser user, IList<string> roles)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        if (user.Email == null) return null;
        
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserName!),
            new Claim(ClaimTypes.Role, string.Join(",", roles)),
            new Claim(ClaimTypes.Email,  user.Email)
        };
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<UserAuthorizedDto?> GenerateAuthorizedToken(string userName, string password)
    {
        var login = await _signInManager
            .PasswordSignInAsync(userName, password, false, false);

        if (login.Succeeded)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName.Equals(userName));

            if (user is not null)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var token = GenerateToken(user, roles);


                return new UserAuthorizedDto
                {
                    Authorized = true,
                    Email = user.Email,
                    ExpiresIn = (int)(DateTime.Now.AddMinutes(15) - DateTime.Now).TotalSeconds,
                    Token = token,
                    UserName = user.UserName
                };
            }
        }

        _notificationContext.AddNotification("NotAuthorized", "Login ou senha incorretos!");
        return null;
    }
}