using DictionaryApplication.Models;
using DictionaryApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DictionaryApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IACcountService _accountService;

    public AccountController(IACcountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(LoginUser user)
    {
        if (await _accountService.Create(user))
        {
            Ok("Succsessfuly done");
        }
        return BadRequest("Something went wrong");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUser user)
    {
        if (ModelState.IsValid)
        {
            var result = await _accountService.Login(user);

            if (result)
            {
                return Ok("Successfully Logged In");
            } 
        }
        return BadRequest();
    }
}