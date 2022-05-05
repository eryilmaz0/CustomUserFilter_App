namespace UserCustomFilter.API.Model;

public class CreateCustomFilterGroupModel
{
    public string FilterGroupName { get; set; }
    public Guid UserId { get; set; }
    public string FilterGroupPicture { get; set; }
}