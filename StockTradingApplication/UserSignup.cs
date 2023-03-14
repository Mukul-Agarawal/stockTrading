using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingApplication
{
    public class UserSignup : ISignup
    {
        User user = new User();
        UserLogin user1 = new UserLogin();
        SqlConnection con = new SqlConnection("server=DEL1-LHP-N70219; database=stockTrading; integrated security=true");
        public void signUp()
        {
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("Enter User Id :");
            user.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter User Name :  ");
            user.name = Console.ReadLine();
            Console.WriteLine("Enter User Trading Amount");
            user.TradingAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter User Password : ");
            user.passwd = Console.ReadLine();
            Console.WriteLine("Enter User Confirm Password : ");
            String cPass = Console.ReadLine();
            if(user.passwd == cPass)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into UserSignUp values(" + user.id + ", ' " + user.name + " ', " + user.TradingAmount + ", ' " + user.passwd + " ' )", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine("\nHello " + user.name + " you are sign up Successfully......");
                    user1.Validation();
                }
                catch(Exception e)
                {
                    Console.WriteLine("\nThis User Id is already taken please take any other..");
                    signUp();
                }
                
            }
            else
            {
                Console.WriteLine("Password Mismatch !!! Please try again...");
                signUp();
            }

            


        }

        //public string ReadPassword()
        //{
        //    string password = "";
        //    ConsoleKeyInfo info = Console.ReadKey(true);
        //    while (info.Key != ConsoleKey.Enter)
        //    {
        //        if (info.Key != ConsoleKey.Backspace)
        //        {
        //            Console.Write("x");
        //            password += info.KeyChar;
        //        }
        //        else if (info.Key == ConsoleKey.Backspace)
        //        {
        //            if (!string.IsNullOrEmpty(password))
        //            {
        //                // remove one character from the list of password characters
        //                password = password.Substring(0, password.Length - 1);
        //                // get the location of the cursor
        //                int pos = Console.CursorLeft;
        //                // move the cursor to the left by one character
        //                Console.SetCursorPosition(pos - 1, Console.CursorTop);
        //                // replace it with space
        //                Console.Write(" ");
        //                // move the cursor to the left by one character again
        //                Console.SetCursorPosition(pos - 1, Console.CursorTop);
        //            }
        //        }
        //        info = Console.ReadKey(true);
        //    }

        //    // add a new line because user pressed enter at the end of their password
        //    Console.WriteLine();
        //    return password;
        //}
    }
}

