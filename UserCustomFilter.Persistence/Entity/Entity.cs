namespace UserCustomFilter.Persistence.Entity;

public abstract class Entity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
    public DateTime Created { get; set; }

    
    public Entity()
    {
        this.Created = DateTime.UtcNow;
    }
}