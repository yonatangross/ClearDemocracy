using Politics.BL.Models;
using Politics.WebApi.Data;

public class FactionType : ObjectType<Faction>
{
    protected override void Configure(IObjectTypeDescriptor<Faction> descriptor)
    {
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Name).Type<StringType>();
        descriptor.Field(x => x.KnessetId).Type<IdType>();
        descriptor.Field(x => x.IsPartial).Type<BooleanType>();

        // Resolve the related MKs
        descriptor.Field<FactionType>(x => x.Id)
            .ResolveWith<Resolvers>(r => r.GetMks(default!, default!))
            .Type<ListType<MkType>>()
            .UseDbContext<ApplicationDbContext>();

        // Resolve the related Knesset
        descriptor.Field<FactionType>(x => x.KnessetId)
            .ResolveWith<Resolvers>(r => r.GetKnesset(default!, default!))
            .Type<KnessetType>()
            .UseDbContext<ApplicationDbContext>();

        private class Resolvers
    {
        public IQueryable<Mk> GetMks([Parent] Faction faction, [Service] ApplicationDbContext context)
        {
            return context.Mks.Where(m => m.FactionId == faction.Id);
        }

        public Knesset GetKnesset([Parent] Faction faction, [Service] ApplicationDbContext context)
        {
            return context.Knessets.FirstOrDefault(k => k.Id == faction.KnessetId);
        }
    }
}
}
