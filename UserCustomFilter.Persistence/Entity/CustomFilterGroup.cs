using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.Persistence.Entity;

public class CustomFilterGroup : Entity<Guid>
{
    public string FilterGroupName { get; set; }
    public Guid UserId { get; set; }
    public string FilterGroupPicture { get; set; }

    #region Navigation Props
    
    public virtual User User { get; set; }
    public virtual ICollection<CustomFilter> Filters { get; set; }
    
    #endregion

    public CustomFilterGroup():base()
    {
        this.Filters = new List<CustomFilter>();
    }
}