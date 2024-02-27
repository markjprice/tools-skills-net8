namespace Northwind.Commerce;

public class Store
{
  // Key is ProductId, Value is Quantity.
  public Dictionary<int, int> Inventory { get; } = new();

  public void AddInventory(int productId, int quantity)
  {
    // Add the specified quantity of the specified product.
    if (Inventory.ContainsKey(productId))
      Inventory[productId] += quantity;
    else
      Inventory.Add(productId, quantity);
  }

  public bool RemoveInventory(int productId, int quantity)
  {
    if (Inventory[productId] >= quantity)
    {
      // Remove the specified quantity of the specified product.
      Inventory[productId] -= quantity;
      return true;
    }
    return false;
  }
}
