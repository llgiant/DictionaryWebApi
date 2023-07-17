using DictionaryApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace DictionaryApplication.Services;

public class AccountService : IACcountService
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Create(LoginUser user)
    {
        IdentityUser identityUser = new()
        {
            UserName = user.UserName,
            Email = user.UserName
        };

        var result = await _userManager.CreateAsync(identityUser, user.Password);
        return result.Succeeded;
    }

    public async Task<bool> Login(LoginUser user)
    {
        var identityUser = await _userManager.FindByEmailAsync(user.UserName);
        if (identityUser is null)
        {
            return false;
        }
        return await _userManager.CheckPasswordAsync(identityUser, user.Password);
    }
}