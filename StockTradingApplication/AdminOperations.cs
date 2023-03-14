using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingApplication
{
    public class AdminOperations
    {
        AdminFunction adf = new AdminFunction();
        public void MenuList()
        {
            Console.WriteLine("\n**************************************************");
            Console.WriteLine("Press 1 for Register new stock");
            Console.WriteLine("Press 2 for View Stock");
            Console.WriteLine("Press 3 for Update Stock");
            Console.WriteLine("Press 4 for View Trader List\n");
    
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    adf.RegisterStock();
                    break;
                case 2:
                    adf.ViewStock();
                    break;
                case 3:
                    adf.UpdateStock();
                    break;
                case 4:
                    adf.ViewTraderList();
                    break;
                default:
                    Console.WriteLine("Invalid Optiopn");
                    break;
            }
        }
    }
}
