using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockTradingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            AdminLogin admin1 = new AdminLogin();
            UserSignup user = new UserSignup();
            UserLogin user1 = new UserLogin();
            Console.WriteLine("***************************");
            Console.WriteLine("Welcome to Stock Trading");
            Console.WriteLine("***************************");

            Console.WriteLine("\nPress 1 for Admin Login ");
            Console.WriteLine("Press 2 for User SignUP");
            Console.WriteLine("Press 3 for User Login\n");
            

            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    admin1.Validation();
                    break;
                case 2:
                    user.signUp();
                    break;
                case 3:
                    user1.Validation();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }
}
