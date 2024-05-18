namespace KnessetService.Api.Models.Input;

public class FactionInput
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int KnessetID { get; set; }
    public bool IsPartial { get; set; }
}

public static class FactionInputExtensions
{
    public static BL.Models.Faction ToBlModel(this FactionInput input)
    {
        return new BL.Models.Faction
        {
            Id = input.ID,
            Name = input.Name,
            KnessetId = input.KnessetID,
            IsPartial = input.IsPartial
        };
    }
}
