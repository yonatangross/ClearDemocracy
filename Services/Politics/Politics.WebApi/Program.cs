using Microsoft.EntityFrameworkCore;
using HotChocolate.AspNetCore.Voyager;
using Aspire.ServiceDefaults;
using Politics.WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

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
    .AddType<MinisterType>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGraphQL();
app.UseVoyager("/graphql", "/voyager");

app.Run();
