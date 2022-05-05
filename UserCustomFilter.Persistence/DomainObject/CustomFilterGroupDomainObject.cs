namespace UserCustomFilter.Persistence.DomainObject;

public class CustomFilterGroupDomainObject
{
    public Guid Id { get; set; }
    public string FilterGroupName { get; set; }
    public string FilterGroupPicture { get; set; }
    public Guid UserId { get; set; }
    public DateTime Created { get; set; }
    public ICollection<CustomFilterBase> CustomFilters { get; set; }
    
}