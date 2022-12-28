using LostFound.Entity.Models;

namespace LostFound.Services.Models;

public class EmployeeModel : BaseModel
{
    public Guid BureauId { get; set; }
    public virtual Bureau Bureau { get; set; }
}