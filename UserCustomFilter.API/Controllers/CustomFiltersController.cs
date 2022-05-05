using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserCustomFilter.API.Model;
using UserCustomFilter.Persistence.Entity;
using UserCustomFilter.Persistence.EntityFramework.Context;

namespace UserCustomFilter.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CustomFiltersController : Controller
{
    private readonly AppDbContext _context;

    public CustomFiltersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomFilter([FromBody] CreateCustomFilterModel request)
    {
        var customFilterGroup = await _context.CustomFilterGroups.FirstOrDefaultAsync(x => x.Id.Equals(request.FilterGroupId));

        if (customFilterGroup is null)
            return BadRequest("Custom Filter Group Not Found.");

        CustomFilter newCustomFilter = new()
        {
            FilterName = request.FilterName,
            FilterPicture = request.FilterPicture,
            FilterType = request.FilterType,
            FirstFilterValue = request.FirstFilterValue,
            SecondFilterValue = request.SecondFilterValue
        };

        customFilterGroup.Filters.Add(newCustomFilter);
        await _context.SaveChangesAsync();
        return Ok("Custom Filter Added.");

    }

    [HttpGet]
    public async Task<IActionResult> GetCustomFilter([FromQuery] Guid filterId)
    {
        var customFilter = await _context.CustomFilters.Include(x => x.FilterGroup).FirstOrDefaultAsync(x => x.Id.Equals(filterId));
        return Ok(customFilter);
    }
}