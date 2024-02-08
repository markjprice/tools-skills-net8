using Microsoft.Data.SqlClient; // To use SqlConnectionStringBuilder.
using Microsoft.EntityFrameworkCore; // To use DbContext and so on.

namespace Northwind.EntityModels;

// This manages interactions with the Northwind database.
public class NorthwindContext : DbContext
{
  public NorthwindContext() { }

  public NorthwindContext(DbContextOptions<NorthwindContext> options)
      : base(options) { }

  // These two properties map to tables in the database.
  public DbSet<Category>? Categories { get; set; }
  public DbSet<Product>? Products { get; set; }

  protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
  {
    // If not already configured by a client project. For example,
    // a client project could use AddNorthwindContext to override
    // the database connection string.

    if (!optionsBuilder.IsConfigured)
    {
      SqlConnectionStringBuilder builder = new();

      builder.DataSource = ".";
      builder.InitialCatalog = "Northwind";
      builder.TrustServerCertificate = true;
      builder.MultipleActiveResultSets = true;

      // If using Azure SQL Edge.
      // builder.DataSource = "tcp:127.0.0.1,1433";

      // Because we want to fail fast. Default is 15 seconds.
      builder.ConnectTimeout = 3;

      // If using Windows Integrated authentication.
      builder.IntegratedSecurity = true;

      // If using SQL Server authentication.
      // builder.UserID = Environment.GetEnvironmentVariable("MY_SQL_USR");
      // builder.Password = Environment.GetEnvironmentVariable("MY_SQL_PWD");

      optionsBuilder.UseSqlServer(builder.ConnectionString);
    }
  }
}
