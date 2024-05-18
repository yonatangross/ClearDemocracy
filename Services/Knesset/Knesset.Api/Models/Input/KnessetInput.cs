namespace KnessetService.Api.Models.Input;

public class KnessetInput
{
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public bool IsCurrent { get; set; }
}

public static class KnessetInputExtensions
{
    public static BL.Models.Knesset ToBlModel(this KnessetInput input)
    {
        return new BL.Models.Knesset
        {
            Id = input.ID,
            Name = input.Name,
            FromDate = input.FromDate,
            ToDate = input.ToDate,
            IsCurrent = input.IsCurrent
        };
    }
}
