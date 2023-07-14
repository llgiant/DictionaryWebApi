using DictionaryApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApplication.Contexts;

public class UserDbContext : IdentityDbContext
{
    public UserDbContext(DbContextOptions options) : base(options)
    {
        
    }
}