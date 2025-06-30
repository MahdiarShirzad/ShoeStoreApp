using System.Security.Cryptography.X509Certificates;
using ShoeStoreApp.Models;

namespace ShoeStoreApp.Services;

public class AdminManager
{
    private List<Shoe> shoes = new();
    private string path = "path";
    
    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Admin Panel ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. View All Products");
            Console.WriteLine("5. Save Products to File");
            Console.WriteLine("6. Show Product Statistics");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("AddProduct() would be called here.");
                    AddProduct();
                    break;
                case "2":
                    Console.WriteLine("RemoveProduct() would be called here.");
                    RemoveProduct();
                    break;
                case "3":
                    Console.WriteLine("EditProduct() would be called here.");
                    break;
                case "4":
                    Console.WriteLine("ViewProducts() would be called here.");
                    break;
                case "5":
                    Console.WriteLine("SaveToFile() would be called here.");
                    break;
                case "6":
                    Console.WriteLine("ShowStatistics() would be called here.");
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
            
            
        }
        
        
    }

    private void AddProduct()
    {
        Console.WriteLine("\n--- Add New Product ---");

        Console.Write("Enter Brand: ");
        var brand = Console.ReadLine();

        Console.Write("Enter Size: ");
        var size = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Color: ");
        var color = Console.ReadLine();

        Console.Write("Enter Price: ");
        var price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Stock Quantity: ");
        var stock = Convert.ToInt32(Console.ReadLine());

        var newId = shoes.Count > 0 ? shoes.Max(s => s.Id) + 1 : 1;

        var newShoe = new Shoe
        {
            Id = newId,
            Brand = brand,
            InStock = stock,
            Price = price,
            Size = size,
            Color = color
        };
        
        shoes.Add(newShoe);
        Console.WriteLine("✅ Product added successfully!");
        Console.WriteLine($"Added Shoe: {newShoe}");
    }

    private void RemoveProduct()
    {
        Console.Write("Enter the ID of the shoe that you want to delete: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int id))
        {
            Console.WriteLine("❌ Invalid ID! Please enter a valid number.");
            return;  
        }

        var shoe =  shoes.FirstOrDefault(shoe => shoe.Id == id);
        if (shoe !=null)
        {
            shoes.Remove(shoe);
            Console.WriteLine("Shoe removed successfully.");
        }
        else
        {
            Console.WriteLine($"Shoe not found with ID {id}");
        }
    }
}