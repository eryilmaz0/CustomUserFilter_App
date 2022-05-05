using UserCustomFilter.Persistence.Enum;

namespace UserCustomFilter.API.Model;

public class CreateCustomFilterModel
{
    public Guid FilterGroupId { get; set; }
    public string FilterName { get; set; }
    public string FilterPicture { get; set; }
    public FilterType FilterType { get; set; }  
    public string FirstFilterValue { get; set; }
    public string SecondFilterValue { get; set; }
}