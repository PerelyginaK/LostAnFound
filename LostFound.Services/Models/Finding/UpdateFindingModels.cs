using LostFound.Entity.Models;

namespace LostFound.Services.Models;

public class UpdateFindingModel
{    
    
    public DateTime TimeRemains { get; set; }
    public double StorageTax { get; set; }
    public string Description { get; set; }
    public string ConditionsOfObtaining { get; set; }
}