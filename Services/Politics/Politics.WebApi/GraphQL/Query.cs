using Politics.BL.Models;
using Politics.WebApi.Data;

public class Query
{
    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Mk> GetMks([Service(ServiceKind.Default)] ApplicationDbContext context) =>
        context.Mks;

    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Faction> GetFactions([Service(ServiceKind.Default)] ApplicationDbContext context) =>
        context.Factions;

    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Knesset> GetKnessets([Service(ServiceKind.Default)] ApplicationDbContext context) =>
        context.Knessets;

    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Government> GetGovernments([Service(ServiceKind.Default)] ApplicationDbContext context) =>
        context.Governments;

    [UseDbContext(typeof(ApplicationDbContext))]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Minister> GetMinisters([Service(ServiceKind.Default)] ApplicationDbContext context) =>
        context.Ministers;
}
