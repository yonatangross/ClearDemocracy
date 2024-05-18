using System.Text.Json.Serialization;

namespace Politics.Api.Models.Input;

public class MKsRoot
{
    [JsonPropertyName("mks")]
    public IList<MkInput> Mks { get; set; }
}

public static class MKsRootExtensions
{
    public static IList<BL.Models.Mk> ToBlModels(this MKsRoot root)
    {
        return root.Mks?.Select(mk => mk.ToBlModel()).ToList();
    }
}
