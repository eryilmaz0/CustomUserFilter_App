using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.API.Model;

public class FilterProductsModel
{
    public List<Product> Products { get; set; }
    public Guid FilterGroupId { get; set; }
}