using Politics.BL.Models;
using Politics.WebApi.Data;

namespace Politics.WebApi.GraphQL;

public class MkType : ObjectType<Mk>
{
    protected override void Configure(IObjectTypeDescriptor<Mk> descriptor)
    {
        descriptor.Field(x => x.MkId).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.FirstName).Type<StringType>();
        descriptor.Field(x => x.LastName).Type<StringType>();
        descriptor.Field(x => x.FactionId).Type<IdType>();
        descriptor.Field(x => x.ImagePath).Type<StringType>();
        descriptor.Field(x => x.FirstLetter).Type<StringType>();
        descriptor.Field(x => x.Email).Type<StringType>();
        descriptor.Field(x => x.Phone).Type<StringType>();
        descriptor.Field(x => x.Gender).Type<StringType>();
        descriptor.Field(x => x.YearDate).Type<IntType>();
        descriptor.Field(x => x.Fax).Type<StringType>();
        descriptor.Field(x => x.Facebook).Type<StringType>();
        descriptor.Field(x => x.Twitter).Type<StringType>();
        descriptor.Field(x => x.Instagram).Type<StringType>();
        descriptor.Field(x => x.Youtube).Type<StringType>();
        descriptor.Field(x => x.IsPresent).Type<BooleanType>();
        descriptor.Field(x => x.IsCoalition).Type<BooleanType>();
        descriptor.Field(x => x.WebsiteUrl).Type<StringType>();

        // Resolve the related Faction
        descriptor.Field<MkType>(mk => mk)
            .ResolveWith<Resolvers>(r => r.GetFaction(default!, default!))
            .Type<FactionType>()
            .UseDbContext<ApplicationDbContext>();
    }

    private class Resolvers
    {
        public Faction GetFaction([Parent] Mk mk, [Service] ApplicationDbContext context)
        {
            return context.Factions.FirstOrDefault(f => f.Id == mk.FactionId);
        }
    }
}
