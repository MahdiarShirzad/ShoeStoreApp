using ShoeStoreApp.Models;

namespace ShoeStoreApp.Services;

public class StoreManager
{
    private List<Shoe> shoes = new();
    private User user = new() { UserId = 1, Name = "Mahdyar" };

    public StoreManager()
    {
        shoes.Add(new Shoe { Id = 1, Brand = "Nike", Size = 42, Color = "Black", Price = 120, InStock = 5 });
        shoes.Add(new Shoe { Id = 2, Brand = "Adidas", Size = 40, Color = "White", Price = 100, InStock = 3 });
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Shoe Store Menu ---");
            Console.WriteLine("1. Show all shoes");
            Console.WriteLine("2. Add to cart");
            Console.WriteLine("3. View cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    
                    ShowAllShoes();
                    break;
                case "2":
                    AddToCart();
                    break;
                case "3":
                    ShowCart();
                    break;
                case "4":
                    Checkout();
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

    private void ShowAllShoes()
    {
        Console.WriteLine("\nAvailable Shoes:");
        foreach (var shoe in shoes)
        {
            Console.WriteLine(shoe);
        }
    }

    private void AddToCart()
    {
        Console.Write("Enter Shoe ID: ");
        if (int.TryParse(Console.ReadLine(), out int shoeId))
        {
            var selected = ProductRepository.Shoes.FirstOrDefault(s => s.Id == shoeId && s.InStock > 0);
            if (selected != null)
            {
                user.Cart.Add(new CartItem { Shoe = selected, Quantity = 1 });
                Console.WriteLine("✅ Shoe added to cart.");
            }
            else
            {
                Console.WriteLine("❌ Shoe not found or out of stock.");
            }
        }
    }

    private void Checkout()
    {
        double total = user.Cart.Sum(item => item.Shoe.Price * item.Quantity);
        foreach (var item in user.Cart)
        {
            item.Shoe.InStock -= item.Quantity;
        }

        ProductRepository.SaveProducts(); // ذخیره به فایل
        user.Cart.Clear();
        Console.WriteLine($"✅ Payment complete. Total: {total} Toman");
    }


    private void ShowCart()
    {
        Console.WriteLine("\nYour Cart:");
        foreach (var item in user.Cart)
        {
            Console.WriteLine($"{item.Shoe.Brand} - {item.Shoe.Price} x {item.Quantity}");
        }
    }
    
}
