using Politics.BL.Models;
using Politics.WebApi.Data;

public class GovernmentType : ObjectType<Government>
{
    protected override void Configure(IObjectTypeDescriptor<Government> descriptor)
    {
        descriptor.Field(x => x.GovId).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.GovName).Type<StringType>();
        descriptor.Field(x => x.GovStartDate).Type<NonNullType<DateType>>();
        descriptor.Field(x => x.GovFinishDate).Type<DateType>();
        descriptor.Field(x => x.GovPmImage).Type<StringType>();
        descriptor.Field(x => x.GovBannerImage).Type<StringType>();
        descriptor.Field(x => x.GovCurrent).Type<BooleanType>();
        descriptor.Field(x => x.SearchedGov).Type<BooleanType>();
        descriptor.Field(x => x.KnessetNames).Type<StringType>();
        descriptor.Field(x => x.GovNotes).Type<StringType>();

        // Resolve the related Ministers
        descriptor.Field<GovernmentType>(x => x.GovId)
            .ResolveWith<Resolvers>(r => r.GetMinisters(default!, default!))
            .Type<ListType<MinisterType>>()
            .UseDbContext<ApplicationDbContext>();

        private class Resolvers
    {
        public IQueryable<Minister> GetMinisters([Parent] Government government, [Service] ApplicationDbContext context)
        {
            return context.Ministers.Where(m => m.GovernmentId == government.GovId);
        }
    }
}
}
