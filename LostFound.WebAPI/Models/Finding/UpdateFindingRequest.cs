namespace LostFound.WebAPI.Models;

public class UpdateFindingRequest
{ 
      public DateTime TimeRemains { get; set; }
    public double StorageTax { get; set; }
    public string Description { get; set; }
    public string ConditionsOfObtaining { get; set; }
}