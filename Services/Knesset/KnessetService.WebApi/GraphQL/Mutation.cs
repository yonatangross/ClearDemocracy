using KnessetService.BL.Models;
using KnessetService.WebApi.Data;

public class Mutation
{
    [UseDbContext(typeof(ApplicationDbContext))]
    public async Task<Mk> AddMkAsync(Mk mk, [ScopedService] ApplicationDbContext context)
    {
        context.Mks.Add(mk);
        await context.SaveChangesAsync();
        return mk;
    }

    [UseDbContext(typeof(ApplicationDbContext))]
    public async Task<Faction> AddFactionAsync(Faction faction, [ScopedService] ApplicationDbContext context)
    {
        context.Factions.Add(faction);
        await context.SaveChangesAsync();
        return faction;
    }

    [UseDbContext(typeof(ApplicationDbContext))]
    public async Task<Knesset> AddKnessetAsync(Knesset knesset, [ScopedService] ApplicationDbContext context)
    {
        context.Knessets.Add(knesset);
        await context.SaveChangesAsync();
        return knesset;
    }

    [UseDbContext(typeof(ApplicationDbContext))]
    public async Task<Government> AddGovernmentAsync(Government government, [ScopedService] ApplicationDbContext context)
    {
        context.Governments.Add(government);
        await context.SaveChangesAsync();
        return government;
    }

    [UseDbContext(typeof(ApplicationDbContext))]
    public async Task<Minister> AddMinisterAsync(Minister minister, [ScopedService] ApplicationDbContext context)
    {
        context.Ministers.Add(minister);
        await context.SaveChangesAsync();
        return minister;
    }
}
