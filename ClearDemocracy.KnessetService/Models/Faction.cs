namespace ClearDemocracy.KnessetService.Api.Models;

public class Faction
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string KnessetID { get; set; }
    public bool IsPartial { get; set; }
}
