using System.Text.RegularExpressions;

namespace GuitarShop.Domain.Entities;

public class Guitar
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public string Brand { get; private set; } = default!;
    public string Model { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Inventory { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Guitar() { }

    public Guitar(string name, string brand, string model, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Guitar name is required.");

        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentException("Brand is required.");

        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Model is required.");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        Id = Guid.NewGuid();
        Name = name;
        Brand = brand;
        Model = model;
        Price = price;
        Inventory = 0;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddInventory(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        Inventory += quantity;
    }

    public void RemoveInventory(int quantity)
    {
        if (quantity > Inventory)
            throw new InvalidOperationException("Not enough inventory");

        Inventory -= quantity;
    }
}
