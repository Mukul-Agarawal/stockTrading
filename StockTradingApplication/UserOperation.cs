using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingApplication
{
    public class UserOperation
    {
        UserFunction userFun = new UserFunction();
        public void MenuList(double amount, int id, string name)
        {
            Console.WriteLine("\n**************************************************");
            Console.WriteLine("Press 1 for View stock");
            Console.WriteLine("Press 2 for Buy Stock");
            Console.WriteLine("Press 3 for Sell Stock\n");

            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    userFun.viewStock(amount, id, name);
                    break;
                case 2:
                    userFun.buyStock(amount, id, name);
                    break;
                case 3:
                    userFun.sellStock(amount, id, name);
                    break;
                default:
                    Console.WriteLine("Invalid Optiopn");
                    break;
            }
        }

    }
}
