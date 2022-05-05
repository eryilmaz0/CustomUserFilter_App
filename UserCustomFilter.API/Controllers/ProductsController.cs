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
public class ProductsController : Controller
{
    private readonly AppDbContext _context;
    private readonly ICustomFilterFactory _factory;

    public ProductsController(AppDbContext context, ICustomFilterFactory factory)
    {
        _context = context;
        _factory = factory;
    }
    
    [HttpPost]
    public async Task<IActionResult> InsertProduct([FromBody] CreateProductModel request)
    {
        Product newProduct = new()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock
        };

        await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();
        return Ok("Product Added.");
    }


    [HttpGet]
    public async Task<IActionResult> FilterProducts([FromQuery] Guid customFilterGroupId)
    {
        var customFilterGroup =
            await _context.CustomFilterGroups.Include(x => x.Filters).FirstOrDefaultAsync(x => x.Id.Equals(customFilterGroupId));

        if (customFilterGroup is null)
            return BadRequest("Filter Group Not Found.");

        var products =  _context.Products.AsEnumerable();
        // IEnumerable<Product> products = new List<Product>(request.Products);
        List<CustomFilterBase> filters = this._factory.GetCustomFilters(customFilterGroup.Filters).ToList();
        
        filters.ForEach(filter =>
        {
            products = filter.Filter(products);
        });

        return Ok(products.ToList());



    }
}