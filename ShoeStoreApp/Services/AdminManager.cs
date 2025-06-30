using System.Security.Cryptography.X509Certificates;
using ShoeStoreApp.Models;

namespace ShoeStoreApp.Services;

public class AdminManager
{
    private List<Shoe> shoes = new();
    private string path = "path";

    public AdminManager()
    {
        shoes.Add(new Shoe { Id = 1, Brand = "Nike", Size = 42, Color = "Black", Price = 120, InStock = 5 });
        shoes.Add(new Shoe { Id = 2, Brand = "Adidas", Size = 40, Color = "White", Price = 100, InStock = 3 });
    }

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
                    EditProduct();
                    break;
                case "4":
                    Console.WriteLine("ViewProducts() would be called here.");
                    ViewAllProducts();
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

        var shoe = shoes.FirstOrDefault(shoe => shoe.Id == id);
        if (shoe != null)
        {
            shoes.Remove(shoe);
            Console.WriteLine("Shoe removed successfully.");
        }
        else
        {
            Console.WriteLine($"Shoe not found with ID {id}");
        }
    }

    private void EditProduct()
    {
        Console.WriteLine("Enter the ID of product that you want to edit : ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int id))
        {
            Console.WriteLine("Invalid ID! Please enter a valid number.");
            return;
        }

        var shoe = shoes.FirstOrDefault(shoe => shoe.Id == id);
        if (shoe == null)
        {
            Console.WriteLine("Shoe not found with that ID.");
            return;
        }

        Console.WriteLine("Current product info:");
        Console.WriteLine(shoe);

        bool editExit = false;

        while (!editExit)
        {
            Console.WriteLine("Which property do you want to edit? ");
            Console.WriteLine("1. Price");
            Console.WriteLine("2. Stock");
            Console.WriteLine("3. Color");
            Console.WriteLine("4. Brand");
            Console.WriteLine("5. Size");
            Console.WriteLine("6. Cancel");

            var property = Convert.ToInt32(Console.ReadLine());

            switch (property)
            {
                case 1:
                    Console.WriteLine("Enter the new Price: ");
                    string priceInput = Console.ReadLine();
                    if (double.TryParse(priceInput, out var newPrice))
                    {
                        shoe.Price = newPrice;
                        Console.WriteLine("Price updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid price.");
                    }

                    break;
                case 2:
                    Console.WriteLine("Enter the new Stock: ");
                    string stockInput = Console.ReadLine();
                    if (Int32.TryParse(stockInput, out var newStock))
                    {
                        shoe.Price = newStock;
                        Console.WriteLine("Stock updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Stock.");
                    }
                    break;
                case 3:
                    Console.Write("Enter the new Color: ");
                    var newColor = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newColor))
                    {
                        Console.WriteLine("Color cannot be empty.");
                    }
                    else
                    {
                        shoe.Color = newColor;
                        Console.WriteLine("Color updated successfully.");
                    }
                    break;
                case 4:
                    Console.Write("Enter the new Brand: ");
                    var newBrand = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newBrand))
                    {
                        Console.WriteLine("Color cannot be empty.");
                    }
                    else
                    {
                        shoe.Brand = newBrand;
                        Console.WriteLine("Color updated successfully.");
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter the new Size: ");
                    string sizeInput = Console.ReadLine();
                    if (Int32.TryParse(sizeInput, out var newSize))
                    {
                        shoe.Size = newSize;
                        Console.WriteLine("Size updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Size Stock.");
                    }

                    break;
                case 6:
                    editExit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    private void ViewAllProducts()
    {
        foreach (var shoe in shoes)
        {
            Console.WriteLine(shoe);
        }
    }
}