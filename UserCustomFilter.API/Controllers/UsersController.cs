using Microsoft.AspNetCore.Mvc;
using UserCustomFilter.API.Model;
using UserCustomFilter.Persistence.Entity;
using UserCustomFilter.Persistence.EntityFramework.Context;

namespace UserCustomFilter.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class UsersController : Controller
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserModel request)
    {
        User user = new()
        {
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return Ok("User Created.");
    }
}