
namespace InventoryHub.Shared.Models
{
// Shared/Models/Product.cs
public class Product
{
    /*
     * GitHub Copilot Contributions:
     *  • Generated a matching constructor for concise `new(...)` usage.
     *  • Advised init-only props to lock down once-constructed state.
     */
    public Product(int id, string name, double price, int stock, Category category)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Category = category;
        }

    public int      Id       { get; init; }
    public string   Name     { get; init; } = string.Empty;
    public double   Price    { get; init; }
    public int      Stock    { get; init; }
    public Category Category { get; init; }
}
}