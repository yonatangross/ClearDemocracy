using Politics.BL.Models;
using Politics.WebApi.Data;

public class MinisterType : ObjectType<Minister>
{
    protected override void Configure(IObjectTypeDescriptor<Minister> descriptor)
    {
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.TypeId).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.GoPositionId).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.SanPositionId).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.PositionName).Type<NonNullType<StringType>>();
        descriptor.Field(x => x.Name).Type<NonNullType<StringType>>();
        descriptor.Field(x => x.MkName).Type<NonNullType<StringType>>();
        descriptor.Field(x => x.FkSanId).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.PosId).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.FactionId).Type<IntType>();
        descriptor.Field(x => x.KnessetId).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.GovernmentId).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.Ordinal).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.MinistryId).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.GovStartDate).Type<NonNullType<DateType>>();
        descriptor.Field(x => x.GovFinishDate).Type<DateType>();
        descriptor.Field(x => x.PositionStartDate).Type<NonNullType<DateType>>();
        descriptor.Field(x => x.PositionFinishedDate).Type<DateType>();
        descriptor.Field(x => x.IsMk).Type<NonNullType<BooleanType>>();
        descriptor.Field(x => x.Gender).Type<NonNullType<StringType>>();
        descriptor.Field(x => x.Notes).Type<StringType>();
        descriptor.Field(x => x.PositionId).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.Rnk).Type<NonNullType<IntType>>();
        descriptor.Field(x => x.PosGroup).Type<NonNullType<IntType>>();

        // Resolve the related Faction
        descriptor.Field<MinisterType>(x => x.FactionId)
            .ResolveWith<Resolvers>(r => r.GetFaction(default!, default!))
            .Type<FactionType>()
            .UseDbContext<ApplicationDbContext>();

        // Resolve the related Knesset
        descriptor.Field<MinisterType>(x => x.KnessetId)
            .ResolveWith<Resolvers>(r => r.GetKnesset(default!, default!))
            .Type<KnessetType>()
            .UseDbContext<ApplicationDbContext>();

        // Resolve the related Government
        descriptor.Field<MinisterType>(x => x.GovernmentId)
            .ResolveWith<Resolvers>(r => r.GetGovernment(default!, default!))
            .Type<GovernmentType>()
            .UseDbContext<ApplicationDbContext>();

        private class Resolvers
    {
        public Faction GetFaction([Parent] Minister minister, [Service] ApplicationDbContext context)
        {
            return context.Factions.FirstOrDefault(f => f.Id == minister.FactionId);
        }

        public Knesset GetKnesset([Parent] Minister minister, [Service] ApplicationDbContext context)
        {
            return context.Knessets.FirstOrDefault(k => k.Id == minister.KnessetId);
        }

        public Government GetGovernment([Parent] Minister minister, [Service] ApplicationDbContext context)
        {
            return context.Governments.FirstOrDefault(g => g.GovId == minister.GovernmentId);
        }
    }
}
}
