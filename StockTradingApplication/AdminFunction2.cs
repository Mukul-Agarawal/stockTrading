using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingApplication
{
    public partial class AdminFunction:IAdminFunction2
    {
        public void UpdateStock()
        {
            
            Console.WriteLine("\n************************************");
            Console.WriteLine("Please enter stock name to be updated ");
            st.stock_Name = Console.ReadLine();
            Console.WriteLine("Press 1 for update Quantity value: ");
            Console.WriteLine("Press 2 for update Stock Buy value: "); 
            Console.WriteLine("Press 3 for update Stock Sell value: ");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {

                case 1:
                    Console.WriteLine("Enter updated stock quantity");
                    st.quantity = int.Parse(Console.ReadLine());
                    SqlCommand cmd1 = new SqlCommand("update stockDetails set quantity= " + st.quantity + " where st_Name = ' " + st.stock_Name + " '", con1);
                    con1.Open();
                    cmd1.ExecuteNonQuery();
                    Console.WriteLine("Stock Quantity Updated Successfully");
                    con1.Close();
                    break;

                case 2:
                    Console.WriteLine("Enter updated stock Buy Price");
                    st.buy_Price = double.Parse(Console.ReadLine());
                    SqlCommand cmd2 = new SqlCommand("update stockDetails set buy_price = " + st.buy_Price + " where st_Name = ' " + st.stock_Name + " '", con1);
                    con1.Open();
                    cmd2.ExecuteNonQuery();
                    Console.WriteLine("Stock Buy Price Updated Successfully");
                    con1.Close();
                    break;

                case 3:
                    Console.WriteLine("Enter updated stock Sell Price");
                    st.sell_Price = double.Parse(Console.ReadLine());
                    SqlCommand cmd3 = new SqlCommand("update stockDetails set sell_price = " + st.sell_Price + " where st_Name = ' " + st.stock_Name + " '", con1);
                    con1.Open();
                    cmd3.ExecuteNonQuery();
                    Console.WriteLine("Stock Quantity Updated Successfully");
                    con1.Close();
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }


            Console.WriteLine("***********************************");
            Console.WriteLine("Do you want to update any other stock then type (yes)....");
            string str = Console.ReadLine();
            if(str.ToLower() == "yes")
            {
                UpdateStock();
            }
        }
        public void ViewTraderList()
        {
            AdminOperations ado = new AdminOperations();
            SqlCommand cmd = new SqlCommand("select * from traderList", con1);
            con1.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("\n*************** Trader List *******************\n");
            table.PrintLine();
            table.PrintRow("userID", "userName", "stockName", "Quantity", "Status", "Trans_Amount", "Trad_Charges");
            table.PrintLine();
            while (dr.Read())
            {
                table.PrintRow(dr["userId"].ToString(), dr["userName"].ToString(), dr["stockName"].ToString(), dr["quantity"].ToString(), dr["status"].ToString(), dr["transactionAmount"].ToString(), dr["tradingCharges"].ToString());
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
