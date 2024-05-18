using Politics.BL.Models;
using Politics.WebApi.Data;

public class FactionType : ObjectType<Faction>
{
    protected override void Configure(IObjectTypeDescriptor<Faction> descriptor)
    {
        descriptor.Field(x => x.Id)
                  .ResolveWith<Resolvers>(x => x.GetMks(default, default))
                  .UseDbContext<ApplicationDbContext>();
    }

    private class Resolvers
    {
        public IQueryable<Mk> GetMks([Parent] Faction faction, [Service(ServiceKind.Resolver)] ApplicationDbContext context)
        {
            return context.Mks.Where(m => m.FactionId == faction.Id);
        }
    }
}
