namespace LostFound.Entity.Models;

public class UserPreviewModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }    
    public virtual City City { get; set; }
    
}