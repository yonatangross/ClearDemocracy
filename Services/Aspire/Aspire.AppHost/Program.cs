var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Politics_WebApi>("politics-webapi");

builder.AddProject<Projects.WebApi_Api>("webapi-api");

builder.Build().Run();
