using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WorkHardApp.DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=CVBD3,1444;Initial Catalog=Beta;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private DataSet Execute(string query)
        {
            DataSet resultSet = new DataSet();

            using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(connectionString))))
            {
                adapter.Fill(resultSet);
            }

            return resultSet;
        }
    }
}
