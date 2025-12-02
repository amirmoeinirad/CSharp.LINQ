namespace LINQ
{
    // Simple model
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------");
            Console.WriteLine("LINQ in C#.NET");
            Console.WriteLine("--------------\n");


            // Sample data
            var products = new List<Product>
            {
                new() { Name = "Laptop",     Category = "Electronics", Price = 1200 },
                new() { Name = "Keyboard",   Category = "Electronics", Price = 40   },
                new() { Name = "Apple",      Category = "Food",        Price = 3    },
                new() { Name = "Banana",     Category = "Food",        Price = 2    },
                new() { Name = "Monitor",    Category = "Electronics", Price = 200  },
                new() { Name = "Bread",      Category = "Food",        Price = 1.5m }
            };


            // ========================
            // 1. FILTERING (Where)
            // ========================

            var expensiveProducts = products
                .Where(p => p.Price > 100)
                .ToList();

            Console.WriteLine("Expensive Products:");
            foreach (var p in expensiveProducts)
                Console.WriteLine($"- {p.Name}");
            
            Console.WriteLine();


            // ========================
            // 2. SELECTING (Projection)
            // ========================
            
            var namesOnly = products
                .Select(p => p.Name);  // Select only the product names

            Console.WriteLine("Product Names:");
            foreach (var name in namesOnly)
                Console.WriteLine($"- {name}");

            Console.WriteLine();


            // ========================
            // 3. SORTING (OrderBy)
            // ========================

            var sortedByPrice = products
                .OrderBy(p => p.Price);   // Ascending order by price

            Console.WriteLine("Products sorted by price:");
            foreach (var p in sortedByPrice)
                Console.WriteLine($"{p.Name}: ${p.Price}");

            Console.WriteLine();


            // ========================
            // 4. GROUPING (GroupBy)
            // ========================
            
            var groupedByCategory = products
                .GroupBy(p => p.Category); // Group products by their Category

            Console.WriteLine("Products grouped by category:");
            foreach (var group in groupedByCategory)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var p in group)
                    Console.WriteLine($"   - {p.Name} (${p.Price})");
            }

            Console.WriteLine();


            // ============================
            // 5. AGGREGATION (Sum, Average)
            // ============================
            
            var totalCost = products.Sum(p => p.Price);
            var averagePrice = products.Average(p => p.Price);

            Console.WriteLine($"Total cost of products: ${totalCost}");
            Console.WriteLine($"Average price: ${averagePrice.ToString("F2")}");

            Console.WriteLine();


            // ======================================
            // 6. ANONYMOUS TYPES (Select new {...})
            // ======================================
            
            var projected = products
                .Select(p => new
                {
                    ProductName = p.Name,
                    PriceWithTax = p.Price * 1.1m // 10% tax added
                });

            Console.WriteLine("Projected anonymous type results:");
            foreach (var item in projected)
                Console.WriteLine($"{item.ProductName} - Price w/ Tax: ${item.PriceWithTax}");


            Console.WriteLine("\nDone.");
        }
    }
}
