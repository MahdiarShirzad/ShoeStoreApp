// Program.cs
using ShoeStoreApp.Services;
using ShoeStoreApp.Models;

class Program
{
    static void Main(string[] args)
    {
        // 1️⃣ initialize our in‑mem & text‑file data
        ProductRepository.Initialize();

        Console.WriteLine("Enter your Mode:\n1. Admin\n2. User");
        if (!int.TryParse(Console.ReadLine(), out int mode))
        {
            Console.WriteLine("Invalid choice"); return;
        }

        if (mode == 1)
        {
            // … your login logic …
            new AdminManager().Run();
        }
        else if (mode == 2)
        {
            new StoreManager().Run();
        }
    }
}