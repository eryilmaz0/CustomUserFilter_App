using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.Persistence.DomainObject;

public class TextFilter : CustomFilterBase
{
    public override IEnumerable<Product> Filter(IEnumerable<Product> products)
    {
        return products.Where(product => product.Name.Contains(this.FirstFilterValue));
    }
}