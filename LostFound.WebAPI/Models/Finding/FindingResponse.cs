namespace LostFound.WebAPI.Models;

public class FindingResponse
{    public Guid BureauId { get; set; }

    public string Name { get; set; }
    public DateTime DateFound { get; set; }
    public DateTime TimeRemains { get; set; }
    public double StorageTax { get; set; }
    public string Description { get; set; }
    public string ConditionsOfObtaining { get; set; }
}