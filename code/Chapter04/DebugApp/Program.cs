using Packt.Shared; // To use WebConfig.
using Northwind.EntityModels; // To use Product.

WebConfig config = new();
config.OutputAll();

Product product = new()
{
  ProductId = 1,
  CategoryId = 1,
  ProductName = "Chai",
  UnitPrice = 1,
  UnitsInStock = 1,
  Discontinued = false
};

WriteLine("Press enter to exit.");
