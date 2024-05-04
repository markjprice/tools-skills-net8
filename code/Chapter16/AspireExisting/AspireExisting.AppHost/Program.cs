var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Northwind_WebApi>("northwind-webapi");

builder.Build().Run();
