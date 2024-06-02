using Microsoft.AspNetCore.Http.HttpResults; // To use Results.
using Microsoft.AspNetCore.Mvc; // To use [FromServices] and so on.
using Northwind.EntityModels; // To use NorthwindContext, Product.
using Northwind.WebApi; // To use MetricsService.

namespace Packt.Extensions;

public static class WebApplicationExtensions
{
  public static WebApplication MapGets(this WebApplication app,
    int pageSize = 10)
  {
    app.MapGet("api/metrics", (
      [FromServices] MetricsService metricsService) => new
    {
      metricsService.RequestCount, metricsService.RequestDurations
    });

    app.MapGet("/", () => "Hello World!")
      .ExcludeFromDescription();

    app.MapGet("api/products", (
      [FromServices] NorthwindContext db,
      [FromQuery] int? page) =>
      db.Products?
        .Where(p => p.UnitsInStock > 0 && !p.Discontinued)
        .OrderBy(product => product.ProductId)
        .Skip(((page ?? 1) - 1) * pageSize)
        .Take(pageSize)
      )
      .WithName("GetProducts")
      .WithOpenApi(operation =>
      {
        operation.Description =
          "Get products with UnitsInStock > 0 and Discontinued = false.";
        operation.Summary = "Get in-stock products that are not discontinued.";
        return operation;
      })
      .Produces<Product[]>(StatusCodes.Status200OK);

    app.MapGet("api/products/outofstock",
      ([FromServices] NorthwindContext db) => db.Products?
        .Where(p => p.UnitsInStock == 0 && !p.Discontinued)
      )
      .WithName("GetProductsOutOfStock")
      .WithOpenApi()
      .Produces<Product[]>(StatusCodes.Status200OK);

    app.MapGet("api/products/discontinued",
      ([FromServices] NorthwindContext db) =>
        db.Products?.Where(product => product.Discontinued)
      )
      .WithName("GetProductsDiscontinued")
      .WithOpenApi()
      .Produces<Product[]>(StatusCodes.Status200OK);

    app.MapGet("api/products/{id:int}",
      async Task<Results<Ok<Product>, NotFound>> (
      [FromServices] NorthwindContext db,
      [FromRoute] int id) => 
      {
        if (db.Products is null)
        { 
          return TypedResults.NotFound();
        }
        else
        {
          return await db.Products.FindAsync(id) is Product product ?
            TypedResults.Ok(product) : TypedResults.NotFound();
        }
      })
      .WithName("GetProductById")
      .WithOpenApi()
      .Produces<Product>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status404NotFound);

    app.MapGet("api/products/{name}", (
      [FromServices] NorthwindContext db,
      [FromRoute] string name) =>
        db.Products?.Where(p => p.ProductName.Contains(name)))
      .WithName("GetProductsByName")
      .WithOpenApi()
      .Produces<Product[]>(StatusCodes.Status200OK);

    return app;
  }
}
