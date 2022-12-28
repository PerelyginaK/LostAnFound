namespace LostFound.Entity.Models;

public class Bureau : BaseEntity
{
    public Guid CityId { get; set; }
    public virtual City City { get; set; }
    
    public string Adress { get; set; }
    public virtual ICollection<Finding> Findings { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }
}