using DatabaseBBMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBBMS.Operations
{
    public class ORecipient
    {
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-PCC2J051\\SQLEXPRESS;Initial Catalog=Recipient_Table;Integrated Security=True");
        public int Submit(ERecipient eRecipient)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Insert into Recipient_Table(Name, Address, Contact) values('" + eRecipient.Name + "', '" + eRecipient.Address + "', " + eRecipient.Contact + ")", connection);
            int check = cmd.ExecuteNonQuery();
            connection.Close();

            return check;
        }
    }
}
