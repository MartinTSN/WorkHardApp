using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WorkHardApp.Entities;

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

        public List<Employee> GetAllCars()
        {
            List<Employee> allCars = new List<Employee>(0);
            string allEmployeeQuery = "SELECT * FROM Cars";

            DataSet resultSet = Execute(allEmployeeQuery);

            DataTable CarsTable = resultSet.Tables[0];

            foreach (DataRow CarRow in CarsTable.Rows)
            {
                int Id = (int)CarRow["Id"];
                string LicensePlate = (string)CarRow["LicensePlate"];
                int ProductionYear = (int)CarRow["ProductionYear"];

                Employee Car = new Employee(id: Id, licensePlate: LicensePlate, productionYear: ProductionYear, make: Make, model: Model, isAvailable: IsAvailable);
                allCars.Add(Car);
            }
            return allCars;
        }
    }
}
