using LostFound.Entity.Models;

namespace LostFound.Services.Models;

public class BureauModel : BaseModel
{
  public Guid CityId { get; set; }
    public virtual City City { get; set; }
    
    public string Adress { get; set; }
}