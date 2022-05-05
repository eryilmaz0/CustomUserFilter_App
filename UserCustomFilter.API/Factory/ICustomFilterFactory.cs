using UserCustomFilter.Persistence.DomainObject;
using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.API.Factory;

public interface ICustomFilterFactory
{
    public ICollection<CustomFilterBase> GetCustomFilters(ICollection<CustomFilter> filters);
}