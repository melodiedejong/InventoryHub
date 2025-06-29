// Shared/Models/Category.cs
namespace InventoryHub.Shared.Models
{
    /*
     * GitHub Copilot Contributions:
     *  • Suggested moving models into the Shared project as single source of truth.
     *  • Recommended using init-only properties for safe immutability.
     */

    public class Category
    {
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}