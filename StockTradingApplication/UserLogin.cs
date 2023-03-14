using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingApplication
{
    public class UserLogin : ILogin
    {
        User user1 = new User();
        UserOperation user_oper = new UserOperation();
        SqlConnection con2 = new SqlConnection("server=DEL1-LHP-N70219; database=stockTrading; integrated security=true");
        public void Validation()
        {
            Console.WriteLine("\n******************************");
            Console.WriteLine("Please Enter your Login Details");
            Console.WriteLine("******************************\n");
            Console.WriteLine("Enter User Id :");
            user1.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter User Name :  ");
            user1.name = Console.ReadLine();
            Console.WriteLine("Enter User Password:  ");
            user1.passwd = Console.ReadLine();

            SqlDataAdapter da = new SqlDataAdapter("select * from UserSignUp", con2);
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "UserSignUp");
            int count = ds1.Tables[0].Rows.Count;
            int flag = 0;

            for (int i = 0; i < count; i++)
            {
                if ((user1.id == int.Parse(ds1.Tables[0].Rows[i][0].ToString())) && (user1.passwd == ds1.Tables[0].Rows[i][3].ToString().Trim()))
                {
                    flag = 1;
                    Console.Clear();
                    Console.WriteLine("\n**************************************************");
                    Console.WriteLine("Welcome " + user1.name + " ......");
                    Console.WriteLine("You are Login in Successfully..");
                    double amount = double.Parse(ds1.Tables[0].Rows[i][2].ToString());
                    user_oper.MenuList(amount, user1.id, user1.name);
                }
               
            }
            if (flag == 0)
            {
                Console.WriteLine("\nInvalid Credentials");
                Console.WriteLine("Please Try Again\n");
                Validation();
            }
        }
    }
}
