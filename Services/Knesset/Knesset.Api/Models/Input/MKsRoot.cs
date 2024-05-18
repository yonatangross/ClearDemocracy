namespace KnessetService.Api.Models.Input;

public class MKsRoot
{
    public IList<MkInput> Mks { get; set; }
}

public static class MKsRootExtensions
{
    public static IList<BL.Models.Mk> ToBlModels(this IList<MkInput> inputs)
    {
        var result = new List<BL.Models.Mk>();
        foreach (var input in inputs)
        {
            result.Add(input.ToBlModel());
        }
        return result;
    }
}
