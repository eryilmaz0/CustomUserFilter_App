using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserCustomFilter.API.Factory;
using UserCustomFilter.API.Model;
using UserCustomFilter.Persistence.DomainObject;
using UserCustomFilter.Persistence.Entity;
using UserCustomFilter.Persistence.EntityFramework.Context;

namespace UserCustomFilter.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CustomFilterGroupsController : Controller
{
    private readonly AppDbContext _context;
    private readonly ICustomFilterFactory _factory;

    public CustomFilterGroupsController(AppDbContext context, ICustomFilterFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomFilterGroup([FromBody] CreateCustomFilterGroupModel request)
    {
        CustomFilterGroup newFilterGroup = new()
        {
            FilterGroupName = request.FilterGroupName,
            UserId = request.UserId,
            FilterGroupPicture = request.FilterGroupPicture
        };

        await _context.CustomFilterGroups.AddAsync(newFilterGroup);
        await _context.SaveChangesAsync();
        return Ok("Filter Group Created.");
    }


    [HttpGet]
    public async Task<IActionResult> GetCsutomFilterGroups()
    {
        var filterGroups = await _context.CustomFilterGroups
                                                    .Include(x => x.Filters)
                                                    .ToListAsync();

        List<CustomFilterGroupDomainObject> customFilterGroups = new();
        
        filterGroups.ForEach(filter =>
        {
            customFilterGroups.Add(new()
            {
                Id = filter.Id,
                FilterGroupName = filter.FilterGroupName,
                FilterGroupPicture = filter.FilterGroupPicture,
                UserId = filter.UserId,
                Created = filter.Created,
                CustomFilters = this._factory.GetCustomFilters(filter.Filters)
            });
        });
        
        return Ok(customFilterGroups);
    }
}