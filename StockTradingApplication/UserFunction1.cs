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
        Stock st = new Stock();
        
        SqlConnection con1= new SqlConnection("server=DEL1-LHP-N70219; database=stockTrading; integrated security=true");

        public void buyStock(double amount, int id, string name)
        {
            UserOperation userOp = new UserOperation();
            Console.Clear();
            Console.WriteLine("\n*********************************************");
            Console.WriteLine("Please Enter Stock Details you want to buy.....");
            Console.WriteLine("*********************************************\n");
            Console.WriteLine("please enter the stock name ");
            st.stock_Name = Console.ReadLine();
            Console.WriteLine("please enter the stock quantity");
            st.quantity = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("select * from stockDetails", con1);
            con1.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string status = "Buy";
            int flag = 0;
            while (dr.Read())
            {
                if (st.stock_Name == dr["st_Name"].ToString().Trim())
                {
                    int quan = int.Parse(dr["quantity"].ToString());
                    double buyAmount = double.Parse(dr["buy_price"].ToString());
                    double feePercent = double.Parse(dr["TradingPercentage"].ToString());
                    
                    if(st.quantity <= quan)
                    {
                        double moneySpend = buyAmount * st.quantity;
                        if(moneySpend < amount)
                        {
                            con1.Close();
                            flag = 1;
                            double fee = (moneySpend * feePercent);
                            SqlCommand cmd1 = new SqlCommand("insert into traderList values(" + id + ", ' " + name + " ', ' " + st.stock_Name + " ', " + st.quantity + ", ' " + status + " ', " + moneySpend + ", " + fee + ")", con1);
                            con1.Open();
                            cmd1.ExecuteNonQuery();
                            con1.Close();
                            addUserStock(id, name, st.stock_Name, st.quantity);
                            updateQuantity(quan - st.quantity, st.stock_Name);
                            updateAmount((amount - (moneySpend + fee)), name);
                            Console.WriteLine("\nCongratulations you buy stock successfully.......");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("you have less balane");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Enter relevant number of quantity");
                    }
                }
            }
            
            if(flag == 0)
            {
                Console.WriteLine("stock does not exist");
                con1.Close();
            }
            Console.WriteLine("\nDo you want to use again user functionality then say (yes)....");
            string resopnse = Console.ReadLine();
            if (resopnse.ToLower() == "yes")
            {
                userOp.MenuList(amount, id, name); 
            }

        }

        public void addUserStock(int id, string name, string stockName, int quantity)
        {
            int flag = 0;
            SqlCommand cmd1 = new SqlCommand("select * from userStock", con1);
            con1.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                if(id == int.Parse(dr["id"].ToString()) && stockName == dr["stock_name"].ToString().Trim())
                {
                    flag = 1;
                    int quan = int.Parse(dr["quantity"].ToString());
                    con1.Close(); 
                    SqlCommand cmd3 = new SqlCommand("update userStock set quantity = " + (quan + quantity) + " where id = " + id + " and stock_name = ' " + stockName + " ' ", con1);
                    con1.Open();
                    cmd3.ExecuteNonQuery();
                    con1.Close();
                    break;
                }
            }
            if(flag == 0)
            {
                con1.Close();
                SqlCommand cmd2 = new SqlCommand("insert into userStock values(" + id + ", ' " + name + " ', ' " + st.stock_Name + " ', " + st.quantity + ")", con1);
                con1.Open();
                cmd2.ExecuteNonQuery();
                con1.Close();
            }
            
        }

        public void updateQuantity(int quantity, string name)
        {
            SqlCommand cmd1 = new SqlCommand("update stockDetails set quantity = " + quantity + " where st_Name = ' " + name + " ' ", con1);
            con1.Open();
            cmd1.ExecuteNonQuery();
            con1.Close();
        }

        public void updateAmount(double amount, string name)
        {
            SqlCommand cmd1 = new SqlCommand("update UserSignUp set TradingAmount = " + amount + " where uName = ' " + name + " ' ", con1);
            con1.Open();
            cmd1.ExecuteNonQuery();
            con1.Close();
        }
    }
}
