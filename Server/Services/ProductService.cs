// Server/Services/ProductService.cs
using InventoryHub.Shared.Models;

namespace InventoryHub.Server.Services
{
    /*
     * GitHub Copilot Contributions:
     *  • Encapsulated mock data in a static service for easier future migration.
     *  • Centralized Category instances to avoid repeated literals.
     *  • Defined an immutable in-memory Product catalog for demo/testing.
     */

    public static class ProductService
    {
        // ─── Category Definitions ──────────────────────────────
        private static readonly Category Electronics = new Category(101, "Electronics");
        private static readonly Category Accessories = new Category(102, "Accessories" );
        private static readonly Category OfficeSupply = new Category(103, "Office Supplies");

        // ─── Immutable In-Memory Product Catalog ─────────────
        private static readonly List<Product> _products = new()
        {
            new(1, "Laptop",             1200.50, 25, Electronics),
            new(2, "Headphones",          50.00,100, Accessories),
            new(3, "Smartphone",         799.99, 40, Electronics),
            new(4, "Wireless Mouse",      25.50,150, Accessories),
            new(5, "Mechanical Keyboard", 89.99, 60, Accessories),
            new(6, "Monitor",            199.99, 30, Electronics),
            new(7, "USB-C Cable",          9.99,300, Accessories),
            new(8, "Webcam",              49.99, 80, Electronics),
            new(9, "Bluetooth Speaker",   59.99, 70, Electronics),
            new(10,"External Hard Drive",120.00, 45, Electronics),
            new(11,"Desk Lamp",           35.00, 90, OfficeSupply),
            new(12,"Notebook",             3.50,500, OfficeSupply)
        };

        /// <summary>
        /// Retrieves the full, read-only list of products.
        /// </summary>
        /// <returns>An IReadOnlyList of Product instances.</returns>
        public static IReadOnlyList<Product> GetProducts() => _products;
    }
}
