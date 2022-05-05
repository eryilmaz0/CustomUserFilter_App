using UserCustomFilter.Persistence.DomainObject;

namespace UserCustomFilter.API.Model;

public class ListFilterGroupWithDetailsModel
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public string FilterGroupName { get; set; }
    public Guid UserId { get; set; }
    public string FilterGroupPicture { get; set; }
    public IEnumerable<CustomFilterBase> CustomFilters { get; set; }
}