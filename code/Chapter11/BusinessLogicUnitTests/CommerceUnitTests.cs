using Northwind.Commerce; // To use Store, Cart.

namespace BusinessLogicUnitTests;

public class CommerceUnitTests
{
  // Factory method to simplify setting up test fixtures.
  private Store CreateStore(int productId, int initialInventory)
  {
    Store store = new();
    store.AddInventory(productId, initialInventory);
    return store;
  }

  [Fact]
  public void Checkout_ShouldReduceInventoryLevel()
  {
    #region Arrange
    int productId = 1;
    int initialInventory = 10;
    Store store = CreateStore(productId, initialInventory);
    Cart sut = new(store);
    int quantityToBuy = 5;
    #endregion

    #region Act
    sut.AddItems(productId, quantityToBuy);
    bool success = sut.Checkout();
    #endregion

    #region Assert
    Assert.True(success);
    int updatedInventory = store.Inventory[productId];
    Assert.Equal(initialInventory - quantityToBuy, updatedInventory);
    #endregion
  }

  [Fact]
  public void Checkout_ShouldFailWhenLowInventory()
  {
    // Arrange
    int productId = 1;
    int initialInventory = 10;
    Store store = CreateStore(productId, initialInventory);
    Cart sut = new(store);
    int quantityToBuy = 15;

    // Act
    sut.AddItems(productId, quantityToBuy);
    bool success = sut.Checkout();

    // Assert
    Assert.False(success);
    int updatedInventory = store.Inventory[productId];
    Assert.Equal(initialInventory, updatedInventory);
  }
}
