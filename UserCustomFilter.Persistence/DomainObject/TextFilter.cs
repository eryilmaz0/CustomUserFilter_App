using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.Persistence.DomainObject;

public class TextFilter : CustomFilterBase
{
    public override IEnumerable<Product> FilterByEnumerable(IEnumerable<Product> products)
    {
        return products.Where(product => product.Name.Contains(this.FirstFilterValue));
    }

    public override IQueryable<Product> FilterByQueryable(IQueryable<Product> products)
    {
        return products.Where(product => product.Name.Contains(this.FirstFilterValue)).AsQueryable();
    }
}