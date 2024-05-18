using KnessetService.BL.Models;
using KnessetService.WebApi.Data;

public class Query
{
    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Mk> GetMks([ScopedService] ApplicationDbContext context) =>
        context.Mks;

    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Faction> GetFactions([ScopedService] ApplicationDbContext context) =>
        context.Factions;

    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Knesset> GetKnessets([ScopedService] ApplicationDbContext context) =>
        context.Knessets;

    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Government> GetGovernments([ScopedService] ApplicationDbContext context) =>
        context.Governments;

    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Minister> GetMinisters([ScopedService] ApplicationDbContext context) =>
        context.Ministers;
}
