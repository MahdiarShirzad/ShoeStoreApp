using ShoeStoreApp.Models;

namespace ShoeStoreApp.Services;

public static class ProductRepository
{
    public static List<Shoe> Shoes { get; private set; } = new();
    private static readonly string filePath = "Products.txt";

    public static void LoadProducts()
    {
        Shoes.Clear();
        if (!File.Exists(filePath)) Console.WriteLine(" file doesn't exist!");
        

        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');

            if (parts.Length == 6 &&
                int.TryParse(parts[0], out int id) &&
                int.TryParse(parts[2], out int size) &&
                double.TryParse(parts[4], out double price) &&
                int.TryParse(parts[5], out int stock))
            {
                Shoes.Add(new Shoe
                {
                    Id = id,
                    Brand = parts[1],
                    Size = size,
                    Color = parts[3],
                    Price = price,
                    InStock = stock
                });
            }
        }
    }

    public static void SaveProducts()
    {
        var lines = Shoes.Select(s => $"{s.Id},{s.Brand},{s.Size},{s.Color},{s.Price},{s.InStock}");
        File.WriteAllLines(filePath, lines);
    }
}