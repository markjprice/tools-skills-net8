namespace Northwind.Commerce;

public class Cart
{
  private readonly Store _store;

  public Cart(Store store)
  {
    _store = store;
  }

  // Key is ProductId, Value is Quantity.
  public Dictionary<int, int> Items { get; } = new();

  public void AddItems(int productId, int quantity)
  {
    // Add the specified quantity of the specified product.
    if (Items.ContainsKey(productId))
      Items[productId] += quantity;
    else
      Items.Add(productId, quantity); 
  }

  public void RemoveItems(int productId, int quantity)
  {
    // Remove the specified quantity of the specified product.
    Items[productId] -= quantity;
  }

  public bool Checkout()
  {
    // Process the cart and charge the customer.
    foreach (var item in Items)
    {
      if (!_store.RemoveInventory(item.Key, item.Value))
      {
        // Unable to remove the item from the inventory.
        return false;
      }
    }
    return true;
  }
}
