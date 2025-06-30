using ShoeStoreApp.Models;
using ShoeStoreApp.Services;

class Program
{
    static void Main(string[] args)
    {
        ProductRepository.LoadProducts();

        Console.WriteLine("Enter your Mode : \n1. Admin \n2. User");
        int mode = Convert.ToInt32(Console.ReadLine());

        if (mode == 1)
        {
            Console.WriteLine("Enter the user name: ");
            var userName = Console.ReadLine();
            Console.WriteLine("Enter the password: ");
            var password = Convert.ToInt32(Console.ReadLine());

            if (userName == "Mahdyar" && password == 5582)
            {
                var admin = new AdminManager();
                admin.Run();
            }
            else
            {
                Console.WriteLine("Username or password is wrong");
            }
        }
        else if (mode == 2)
        {
            var store = new StoreManager();
            store.Run();
        }
        else
        {
            Console.WriteLine("Entered invalid number!");
        }
    }
}