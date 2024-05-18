using KnessetService.WebApi.Data;
using KnessetService.BL.Models;

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
        public Faction GetFaction([Parent] Mk mk, [ScopedService] ApplicationDbContext context)
        {
            return context.Factions.FirstOrDefault(f => f.Id == mk.FactionId);
        }
    }
}

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
        public IQueryable<Mk> GetMks([Parent] Faction faction, [ScopedService] ApplicationDbContext context)
        {
            return context.Mks.Where(m => m.FactionId == faction.Id);
        }
    }
}

public class KnessetType : ObjectType<Knesset>
{
    protected override void Configure(IObjectTypeDescriptor<Knesset> descriptor)
    {
    }
}

public class GovernmentType : ObjectType<Government>
{
    protected override void Configure(IObjectTypeDescriptor<Government> descriptor)
    {
    }
}

public class MinisterType : ObjectType<Minister>
{
    protected override void Configure(IObjectTypeDescriptor<Minister> descriptor)
    {
    }
}
