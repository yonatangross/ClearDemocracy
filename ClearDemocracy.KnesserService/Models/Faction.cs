namespace ClearDemocracy.KnessetService.Models;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Faction
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string KnessetID { get; set; }
    public bool IsPartial { get; set; }
}
