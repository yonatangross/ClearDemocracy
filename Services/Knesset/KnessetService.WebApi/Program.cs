using Microsoft.EntityFrameworkCore;
using KnessetService.WebApi.Data;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("GraphQLDemo"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<MkType>()
    .AddType<FactionType>()
    .AddType<KnessetType>()
    .AddType<GovernmentType>()
    .AddType<MinisterType>();

var app = builder.Build();

app.MapGraphQL();
app.UseVoyager("/graphql", "/voyager");

app.Run();
