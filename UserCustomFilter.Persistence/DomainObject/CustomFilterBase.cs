using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.Persistence.DomainObject;

public abstract class CustomFilterBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
    public string FirstFilterValue { get; set; }
    public string SecondFilterValue { get; set; }
    public DateTime Created { get; set; }

    public abstract IEnumerable<Product> Filter(IEnumerable<Product> products);
}