namespace ClearDemocracy.KnessetService.Api.Models;

public class GovernmentRoot
{
    [System.Text.Json.Serialization.JsonPropertyName("GovermentsNames")]
    public List<Government> GovermentsNames { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("GovermentPositions")]
    public List<Minister> Ministers { get; set; }
    [System.Text.Json.Serialization.JsonPropertyName("GovermentPositionsLast")]
    public List<MinisterLastPosition> MinisterLastPositions { get; set; }
    public List<object> GovermentDocs { get; set; }
    public List<object> GovermentEmbededVideos { get; set; }
}
