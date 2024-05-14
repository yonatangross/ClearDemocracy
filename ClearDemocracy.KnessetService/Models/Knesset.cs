namespace ClearDemocracy.KnessetService.Models;

public class Knesset
{
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public string FromDateHeb { get; set; }
    public string ToDateHeb { get; set; }
    public bool IsCurrent { get; set; }
}
