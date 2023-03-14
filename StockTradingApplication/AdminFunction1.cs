using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingApplication
{
    public partial class AdminFunction : IAdminFunction1
    {
        Stock st = new Stock();
        SqlConnection con1 = new SqlConnection("server=DEL1-LHP-N70219; database=stockTrading; integrated security=true");
        PrintTableFormat table = new PrintTableFormat();

        public void RegisterStock()
        {
            AdminOperations ado = new AdminOperations();
            Console.WriteLine("\n***************************");
            Console.WriteLine("Enter Stock Name");
            st.stock_Name = Console.ReadLine();
            Console.WriteLine("\nEnter Company Name");
            st.company_Name = Console.ReadLine();
            Console.WriteLine("\nEnter Stock Quantity");
            st.quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter Stock Buy Price");
            st.buy_Price = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter Stock Sell Price");
            st.sell_Price = double.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter Stock Trading Fee Percentage");
            st.TradingFeePercentage = double.Parse(Console.ReadLine());


            try
            {
                SqlCommand cmd1 = new SqlCommand("insert into stockDetails values(' " + st.stock_Name + " ', ' " + st.company_Name + " ', "+ st.quantity + ", " + st.buy_Price + ", " + st.sell_Price + ", " + st.TradingFeePercentage + ")", con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("\nstock are present already....");

            }
            Console.WriteLine("\nDo you want to insert another stock then write (yes)....");
            string newRegister = Console.ReadLine();
            if(newRegister.ToLower() == "yes")
            {
                RegisterStock();
            }
            ado.MenuList();
        }
        
        public void ViewStock()
        {
            AdminOperations ado = new AdminOperations();
            SqlCommand cmd = new SqlCommand("select * from stockDetails", con1);
            con1.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("\n*************** Total stock *******************\n");

            table.PrintLine();
            table.PrintRow("st_Name", "comp_Name", "Quantity", "Buy_Price", "Sell_Price");
            table.PrintLine();
            while (dr.Read())
            {
                table.PrintRow(dr["st_name"].ToString(), dr["comp_name"].ToString(), dr["quantity"].ToString(), dr["buy_price"].ToString(), dr["sell_price"].ToString());
            }
            table.PrintLine();
            con1.Close();
            Console.WriteLine("\nDo you want to use again admin functionality then say (yes)....");
            string newRegister = Console.ReadLine();
            if (newRegister.ToLower() == "yes")
            {
                ado.MenuList();
            }
            
        }

    }
}

   