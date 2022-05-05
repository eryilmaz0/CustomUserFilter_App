using UserCustomFilter.Persistence.Entity;
using UserCustomFilter.Persistence.Enum;

namespace UserCustomFilter.Persistence.Entity;

public class CustomFilter : Entity<Guid>
{
    public Guid FilterGroupId { get; set; }
    public string FilterName { get; set; }
    public string FilterPicture { get; set; }
    public FilterType FilterType { get; set; }  
    public string FirstFilterValue { get; set; }
    public string SecondFilterValue { get; set; }

    #region Navigation Props

    public virtual CustomFilterGroup FilterGroup { get; set; }
    
    #endregion

    public CustomFilter():base()
    {
        
    }
}