using ShoeStoreApp.Models;
using ShoeStoreApp.Services;
using AdminManager = ShoeStoreApp.Services.AdminManager;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter your Mode:\n1. Admin\n2. User");

            if (!int.TryParse(Console.ReadLine(), out int mode))
            {
                Console.WriteLine("Please enter a valid number!");
                continue;
            }

            if (mode == 1)
            {
                Console.Write("Enter the username: ");
                var userName = Console.ReadLine();

                Console.Write("Enter the password: ");
                var password = Console.ReadLine();

                if (userName == "Mahdyar" && password == "5582")
                {
                    var admin = new AdminManager();
                    admin.Run();
                    break; 
                }
                else
                {
                    Console.WriteLine("Username or password is incorrect.");
                }
            }
            else if (mode == 2)
            {
                var store = new StoreManager();
                store.Run();
                break; 
            }
            else
            {
                Console.WriteLine("Invalid number! Try again.\n");
            }
        }
    }
}