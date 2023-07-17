using DictionaryApplication.Models;

namespace DictionaryApplication.Services;

public interface IACcountService
{
    Task<bool> Login(LoginUser user);
    Task<bool> Create(LoginUser user);
}