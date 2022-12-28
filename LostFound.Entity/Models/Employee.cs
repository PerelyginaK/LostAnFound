namespace LostFound.Entity.Models;

public class Employee : BaseEntity
{
    public Guid BureauId { get; set; }
    public virtual Bureau Bureau { get; set; }

    public string PasswordHash { get; set; }
}