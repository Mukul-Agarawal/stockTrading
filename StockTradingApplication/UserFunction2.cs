using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingApplication
{
    public partial class UserFunction
    {
        PrintTableFormat table = new PrintTableFormat();
        public void sellStock(double amount, int id, string name)
        {
            UserOperation userOp = new UserOperation();
            Console.Clear();
            Console.WriteLine("\n*********************************************");
            Console.WriteLine("Please Enter Stock Details you want to sell.....");
            Console.WriteLine("*********************************************\n");
            Console.WriteLine("please enter the stock name ");
            st.stock_Name = Console.ReadLine();
            Console.WriteLine("please enter the stock quantity");
            st.quantity = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd1 = new SqlCommand("select quantity from userStock where id = " + id + " and stock_name = ' " + st.stock_Name + " ' ", con1);
            con1.Open();
            int quan = (Int32)cmd1.ExecuteScalar();
            con1.Close();
            SqlCommand cmd = new SqlCommand("select * from stockDetails", con1);
            con1.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string status = "Sell";
            int flag = 0;
            while (dr.Read())
            {
                if (st.stock_Name == dr["st_Name"].ToString().Trim())
                {
                    int stQuantity = int.Parse(dr["quantity"].ToString());
                    double sellAmount = double.Parse(dr["sell_price"].ToString());
                    double feePercent = double.Parse(dr["TradingPercentage"].ToString());

                    if (st.quantity <= quan)
                    {
                        double moneyReceive = sellAmount * st.quantity;
                        con1.Close();
                        flag = 1;
                        double fee = (moneyReceive * feePercent);
                        SqlCommand cmd2 = new SqlCommand("insert into traderList values(" + id + ", ' " + name + " ', ' " + st.stock_Name + " ', " + st.quantity + ", ' " + status + " ', " + moneyReceive + ", " + fee + ")", con1);
                        con1.Open();
                        cmd2.ExecuteNonQuery();
                        con1.Close();
                        SqlCommand cmd3 = new SqlCommand("update userStock set quantity = " + (quan- st.quantity) + " where id = " + id + " and stock_name = ' " + st.stock_Name + " ' ", con1);
                        con1.Open();
                        cmd3.ExecuteNonQuery();
                        con1.Close();
                        updateQuantity(stQuantity + st.quantity, st.stock_Name);
                        updateAmount((amount + (moneyReceive - fee)), name);
                        Console.WriteLine("Congrats you sell stock successfully....");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter relevant number of quantity");
                    }
                    
                }
            }
            
            if (flag == 0)
            {
                Console.WriteLine("you don't have enough amount of stock......");
                con1.Close();
            }
            Console.WriteLine("\nDo you want to use again user functionality then say (yes)....");
            string resopnse = Console.ReadLine();
            if (resopnse.ToLower() == "yes")
            {
                userOp.MenuList(amount, id, name);
            }

        }

        public void viewStock(double amount, int id, string name)
        {
            UserOperation userOp = new UserOperation();
            SqlCommand cmd = new SqlCommand("select * from stockDetails", con1);
            con1.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("\n*************** Total stock *******************\n");
            table.PrintLine();
            table.PrintRow("st_Name", "comp_Name", "Quantity", "Buy_Price", "Sell_Price");
            table.PrintLine();
            while (dr.Read())
            {
                table.PrintRow(dr["st_name"].ToString(), dr["comp_name"].ToString(), dr["quantity"].ToString(), dr["buy_Price"].ToString(), dr["sell_Price"].ToString());
            }
            table.PrintLine();
            con1.Close();
            Console.WriteLine("\nDo you want to use again user functionality then say (yes)....");
            string resopnse = Console.ReadLine();
            if (resopnse.ToLower() == "yes")
            {
                userOp.MenuList(amount, id, name);
            }
        }
    }
}
