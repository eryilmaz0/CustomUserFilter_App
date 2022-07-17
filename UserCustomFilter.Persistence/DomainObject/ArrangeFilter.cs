using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.Persistence.DomainObject;

public class ArrangeFilter : CustomFilterBase
{
    public override IEnumerable<Product> FilterByEnumerable(IEnumerable<Product> products)
    {
        var minPriceParse = decimal.TryParse(this.FirstFilterValue, out decimal minPriceLimit);
        var maxPriceParse = decimal.TryParse(this.SecondFilterValue, out decimal maxPriceLimit);

        if (!minPriceParse || !maxPriceParse)
            throw new ApplicationException("Exception has been occured when parsing limit parameters.");
        
        return products.Where(product => product.Price >= minPriceLimit && product.Price <= maxPriceLimit);
    }
    

    public override IQueryable<Product> FilterByQueryable(IQueryable<Product> products)
    {
        var minPriceParse = decimal.TryParse(this.FirstFilterValue, out decimal minPriceLimit);
        var maxPriceParse = decimal.TryParse(this.SecondFilterValue, out decimal maxPriceLimit);

        if (!minPriceParse || !maxPriceParse)
            throw new ApplicationException("Exception has been occured when parsing limit parameters.");
        
        return products.Where(product => product.Price >= minPriceLimit && product.Price <= maxPriceLimit).AsQueryable();
    }
}