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
        private string connectionString = @"Data Source=CVDB3,1444;Initial Catalog=Beta;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private DataSet Execute(string query)
        {
            DataSet resultSet = new DataSet();

            using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(connectionString))))
            {
                adapter.Fill(resultSet);
            }

            return resultSet;
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> allEmployees = new List<Employee>(0);
            string allEmployeeQuery = "SELECT * FROM Employees";

            DataSet resultSet = Execute(allEmployeeQuery);

            DataTable EmployeeTable = resultSet.Tables[0];

            foreach (DataRow EmployeeRow in EmployeeTable.Rows)
            {
                int Id = (int)EmployeeRow["Id"];
                string Firstname = (string)EmployeeRow["Firstname"];
                string Lastname = (string)EmployeeRow["Lastname"];

                Employee employee = new Employee(id: Id, firstName: Firstname, lastName: Lastname);
                allEmployees.Add(employee);
            }
            return allEmployees;
        }

        public void CheckIn(Employee employee)
        {
            string checkInQuery = $"INSERT INTO CheckIns (Employee,CheckInTime,Absence) VALUES({employee.Id},'{DateTime.Now}',0)";
            Execute(checkInQuery);
        }
    }
}
