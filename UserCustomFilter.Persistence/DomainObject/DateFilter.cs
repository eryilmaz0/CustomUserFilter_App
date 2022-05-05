using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.Persistence.DomainObject;

public class DateFilter : CustomFilterBase
{
    public override IEnumerable<Product> Filter(IEnumerable<Product> products)
    {
        var minDateParse = DateTime.TryParse(this.FirstFilterValue, out DateTime minDateTime);
        var maxDateParse = DateTime.TryParse(this.SecondFilterValue, out DateTime maxDateTime);

        if (!maxDateParse || !maxDateParse)
            throw new ApplicationException("Exception has been occured when parsing date parameters.");

        return products.Where(x => x.Created >= minDateTime || x.Created <= maxDateTime);
    }
}