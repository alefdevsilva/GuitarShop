using FluentAssertions;
using GuitarShop.Domain.Entities;

namespace GuitarShop.Tests.Domain.Entities;

public class GuitarTests
{
    [Fact]
    public void Constructor_GivenValidData_ShouldCreateGuitar()
    {
        // Arrange
        var name = "Stratocaster";
        var brand = "Fender";
        var model = "American Pro II";
        var price = 12000m;

        // Act
        var guitar = new Guitar(name, brand, model, price);

        // Assert
        guitar.Should().NotBeNull();
        guitar.Name.Should().Be(name);
        guitar.Brand.Should().Be(brand);
        guitar.Model.Should().Be(model);
        guitar.Price.Should().Be(price);
        guitar.Inventory.Should().Be(0);
        guitar.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_GivenNullName_ThenShouldThrow(string name)
    {
        // Arrange
        var brand = "Fender";
        var model = "Strat";
        var price = 1000m;

        // Act
        Action act = () => new Guitar(name, brand, model, price);

        // Assert
        act.Should().Throw<ArgumentException>()
          .WithMessage("Guitar name is required.");
    }

    [Fact]
    public void Constructor_GivenPriceLessThanZero_ThenShouldThrow()
    {
        // Arrange
        var name = "Les Paul";
        var brand = "Gibson";
        var model = "Standard";
        var price = -100m;

        // Act
        Action act = () => new Guitar(name, brand, model, price);

        // Assert
        act.Should().Throw<ArgumentException>()
          .WithMessage("Price must be greater than zero.");
    }

    [Fact]
    public void AddInventory_GivenValidQuantity_ShouldIncreaseInventory()
    {
        // Arrange
        var guitar = new Guitar("Telecaster", "Fender", "Player", 5000m);

        // Act
        guitar.AddInventory(10);

        // Assert
        guitar.Inventory.Should().Be(10);
    }

    [Fact]
    public void AddInventory_GivenQuantityLessThanZero_ThenShouldThrow()
    {
        // Arrange
        var guitar = new Guitar("Telecaster", "Fender", "Player", 5000m);

        // Act
        Action act = () => guitar.AddInventory(-5);

        // Assert
        act.Should().Throw<ArgumentException>()
          .WithMessage("Quantity must be greater than zero");
    }

    [Fact]
    public void RemoveInventory_GivenQuantityGreaterThanStock_ThenShouldThrow()
    {
        // Arrange
        var guitar = new Guitar("Telecaster", "Fender", "Player", 5000m);
        guitar.AddInventory(5);

        // Act
        Action act = () => guitar.RemoveInventory(10);

        // Assert
        act.Should().Throw<InvalidOperationException>()
          .WithMessage("Not enough inventory");
    }

    [Fact]
    public void RemoveInventory_GivenValidQuantity_ShouldDecreaseInventory()
    {
        // Arrange
        var guitar = new Guitar("Telecaster", "Fender", "Player", 5000m);
        guitar.AddInventory(10);

        // Act
        guitar.RemoveInventory(3);

        // Assert
        guitar.Inventory.Should().Be(7);
    }
}