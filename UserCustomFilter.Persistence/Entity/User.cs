using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.Persistence.Entity;

public class User : Entity<Guid>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    #region Navigation Props
    
    public virtual ICollection<CustomFilterGroup> CustomFilters { get; set; }
    
    #endregion
    
    public User():base()
    {
        
    }
}