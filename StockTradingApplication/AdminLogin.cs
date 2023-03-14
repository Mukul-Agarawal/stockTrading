using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingApplication
{
    public class AdminLogin : ILogin
    {

        Admin admin = new Admin();
        AdminOperations adminOp = new AdminOperations();
        SqlConnection con = new SqlConnection("server=DEL1-LHP-N70219; database=stockTrading; integrated security=true");

        public void Validation()
        {
            Console.WriteLine("\n***************************");
            Console.WriteLine("Enter Admin Id :");
            admin.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Admin Name :  ");
            admin.name = Console.ReadLine();
            Console.WriteLine("Enter Admin Password:  ");
            admin.passwd = Console.ReadLine();

            SqlDataAdapter da = new SqlDataAdapter("select * from AdminLogin", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "AdminLogin");
            int count = ds.Tables[0].Rows.Count;
            int flag = 0;

            for (int i = 0; i < count; i++)
            {
                if ((admin.id == int.Parse(ds.Tables[0].Rows[i][0].ToString())) && (admin.passwd == ds.Tables[0].Rows[i][2].ToString()))
                {
                    flag = 1;
                    Console.WriteLine("\n**************************************************");
                    Console.WriteLine("Welcome back " + admin.name + " in a Stock admin Portal");
                    adminOp.MenuList();
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

