namespace UserCustomFilter.Persistence.Entity;

public interface IEntity<TId> 
{
    public TId Id { get; set; }
    public DateTime Created { get; set; }
}