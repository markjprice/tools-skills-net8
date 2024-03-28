using Testcontainers.MsSql; // To use MsSqlContainer.

namespace NorthwindTests;

public class DatabaseIntegrationTests
{
  private MsSqlContainer? _sqlContainer;

  private async Task SetUp()
  {
    MsSqlConfiguration configuration = new(
      database: "Northwind",
      username: "sa",
      password: "s3cret-n1nj@"
    );

    _sqlContainer = new(configuration);

    await _sqlContainer.StartAsync();
  }

  [Fact]
  public async Task TestDatabaseConnection()
  {
    await SetUp();

    // Use _sqlContainer.ConnectionString to connect and interact with the SQL Server

    await TearDown();
  }

  private async Task TearDown()
  {
    await _sqlContainer.StopAsync();
  }
}