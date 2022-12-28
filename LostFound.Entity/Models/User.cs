namespace LostFound.Entity.Models;

public class User : BaseEntity
{
    public Guid CityId { get; set; }
    public virtual City City { get; set; }

    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
}