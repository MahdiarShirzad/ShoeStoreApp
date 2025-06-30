// Services/ProductRepository.cs
using ShoeStoreApp.Models;
using System.IO;
using System.Linq;

namespace ShoeStoreApp.Services
{
    public static class ProductRepository
    {
        public static List<Shoe> Shoes { get; private set; } = new();

        private static readonly string filePath = "Products.txt";

        // Call this once at program start
        public static void Initialize()
        {
            // If no file / empty file, seed defaults and persist
            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                Shoes = new List<Shoe>
                {
                    new Shoe { Id = 1, Brand = "Nike",   Size = 42, Color = "Black", Price = 120, InStock = 5 },
                    new Shoe { Id = 2, Brand = "Adidas", Size = 40, Color = "White", Price = 100, InStock = 3 }
                };
                SaveProducts();
            }
            else
            {
                LoadProducts();
            }
        }

        public static void LoadProducts()
        {
            Shoes.Clear();
            foreach (var line in File.ReadAllLines(filePath))
            {
                var p = line.Split(',');
                if (p.Length == 6
                    && int.TryParse(p[0], out int id)
                    && int.TryParse(p[2], out int size)
                    && double.TryParse(p[4], out double price)
                    && int.TryParse(p[5], out int stock))
                {
                    Shoes.Add(new Shoe
                    {
                        Id      = id,
                        Brand   = p[1],
                        Size    = size,
                        Color   = p[3],
                        Price   = price,
                        InStock = stock
                    });
                }
            }
        }

        public static void SaveProducts()
        {
            var lines = Shoes
                .Select(s => $"{s.Id},{s.Brand},{s.Size},{s.Color},{s.Price},{s.InStock}");
            File.WriteAllLines(filePath, lines);
        }
    }
}
