using UserCustomFilter.Persistence.DomainObject;
using UserCustomFilter.Persistence.Entity;
using UserCustomFilter.Persistence.Enum;

namespace UserCustomFilter.API.Factory;

public class CustomFilterFactory : ICustomFilterFactory
{
    public ICollection<CustomFilterBase> GetCustomFilters(ICollection<CustomFilter> filters)
    {
        ICollection<CustomFilterBase> filtersList = new List<CustomFilterBase>();

        foreach (var filter in filters)
        {
            CustomFilterBase newFilter = filter.FilterType switch
            {
                FilterType.TextFilter => new TextFilter()
                {
                    Id = filter.Id,
                    Name = filter.FilterName,
                    Picture = filter.FilterPicture,
                    FirstFilterValue = filter.FirstFilterValue,
                    Created = filter.Created
                },
                
                FilterType.ArrangeFilter => new ArrangeFilter()
                {
                    Id = filter.Id,
                    Name = filter.FilterName,
                    Picture = filter.FilterPicture,
                    FirstFilterValue = filter.FirstFilterValue,
                    SecondFilterValue = filter.SecondFilterValue,
                    Created = filter.Created
                }, 
                
                FilterType.DateFilter => new DateFilter()
                {
                    Id = filter.Id,
                    Name = filter.FilterName,
                    Picture = filter.FilterPicture,
                    FirstFilterValue = filter.FirstFilterValue,
                    Created = filter.Created
                },
                
                _ => throw new ApplicationException("Unexpected Case.")
            };

            filtersList.Add(newFilter);
        }

        return filtersList;
    }
}