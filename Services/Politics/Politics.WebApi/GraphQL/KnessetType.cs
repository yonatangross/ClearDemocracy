using Politics.BL.Models;
using Politics.WebApi.Data;

public class KnessetType : ObjectType<Knesset>
{
    protected override void Configure(IObjectTypeDescriptor<Knesset> descriptor)
    {
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Name).Type<StringType>();
        descriptor.Field(x => x.FromDate).Type<NonNullType<DateType>>();
        descriptor.Field(x => x.ToDate).Type<DateType>();
        descriptor.Field(x => x.IsCurrent).Type<BooleanType>();

        // Resolve the related Factions
        descriptor.Field<KnessetType>(x => x.Id)
            .ResolveWith<Resolvers>(r => r.GetFactions(default!, default!))
            .Type<ListType<FactionType>>()
            .UseDbContext<ApplicationDbContext>();

        // Resolve the related Ministers
        descriptor.Field<KnessetType>(x => x.Id)
            .ResolveWith<Resolvers>(r => r.GetMinisters(default!, default!))
            .Type<ListType<MinisterType>>()
            .UseDbContext<ApplicationDbContext>();

        private class Resolvers
    {
        public IQueryable<Faction> GetFactions([Parent] Knesset knesset, [Service] ApplicationDbContext context)
        {
            return context.Factions.Where(f => f.KnessetId == knesset.Id);
        }

        public IQueryable<Minister> GetMinisters([Parent] Knesset knesset, [Service] ApplicationDbContext context)
        {
            return context.Ministers.Where(m => m.KnessetId == knesset.Id);
        }
    }
}
}
