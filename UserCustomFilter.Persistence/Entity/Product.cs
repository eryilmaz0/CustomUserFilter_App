namespace UserCustomFilter.Persistence.Entity;

public class Product : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Product():base()
    {
        
    }
}