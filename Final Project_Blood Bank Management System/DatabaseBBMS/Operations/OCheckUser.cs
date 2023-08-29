using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBBMS.Operations
{

    public class OCheckUser
    {
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-PCC2J051\\SQLEXPRESS;Initial Catalog=Recipient_Table;Integrated Security=True");
        
        public string Check(string tableName, string username, string password)
        {
            connection.Open();
            SqlCommand userCmd = new SqlCommand("Select count(*) from "+tableName+" Where Username='"+username+"'", connection);
            int resultRow = Convert.ToInt32(userCmd.ExecuteScalar());
            connection.Close();

            if (resultRow > 0)
            {
                connection.Open();
                SqlCommand passCmd = new SqlCommand("Select Password from "+tableName+" Where Username='" + username+"'", connection);
                if (password == passCmd.ExecuteScalar().ToString())
                {
                    return "Logged In Successfully!";
                }
                else
                {
                    return "Password Incorrect!";
                }
            }
            else
            {
                return "Username not Exist!";
            }
        }

    }

    
}
