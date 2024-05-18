using Politics.BL.Models;
using Politics.WebApi.Data;

public class MkType : ObjectType<Mk>
{
    protected override void Configure(IObjectTypeDescriptor<Mk> descriptor)
    {
        descriptor.Field(x => x.FactionId)
                  .ResolveWith<Resolvers>(x => x.GetFaction(default, default))
                  .UseDbContext<ApplicationDbContext>();
    }

    private class Resolvers
    {
        public Faction GetFaction([Parent] Mk mk, [Service(ServiceKind.Resolver)] ApplicationDbContext context)
        {
            return context.Factions.FirstOrDefault(f => f.Id == mk.FactionId);
        }
    }
}
