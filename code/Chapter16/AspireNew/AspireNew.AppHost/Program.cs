var builder = DistributedApplication.CreateBuilder(args);

builder.AddPostgres("postgres")
  .WithPgAdmin()
  .AddDatabase("cms");

builder.AddSqlServer("sqlserver")
  .AddDatabase("northwind");

builder.AddProject<Projects.Northwind_WebApi>("northwind-webapi");

builder.Build().Run();
