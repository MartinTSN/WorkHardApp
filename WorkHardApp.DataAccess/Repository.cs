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
            
            string checkInQuery = $"INSERT INTO CheckIns (Employee,CheckInTime,Absence) VALUES({employee.Id},'{DateTime.Now.ToString("yyyy/MM/dd")}',0)";
            Execute(checkInQuery);
        }

        public void CheckOut(Employee employee)
        {
            string checkOutQuery = $"UPDATE CheckIns SET CheckOutTime='{DateTime.Now}' WHERE Employee={employee.Id}";
            Execute(checkOutQuery);
        }

        public bool CheckIfCheckedIn(Employee employee)
        {
            bool checkedIn;
            string query = $"SELECT * FROM CheckIns WHERE Employee={employee.Id} CheckInTime<>'NULL' AND CheckOutTime='NULL'";
            DataSet resultSet = Execute(query);
            DataTable CheckInTable = resultSet.Tables[0];
            int amountOfRows = CheckInTable.Rows.Count;
            if(amountOfRows == 0)
            {
                checkedIn = false;
            }
            else if (amountOfRows == 1)
            {
                checkedIn = true;
            }
            else
            {
                throw new ArgumentException();
            }
            return checkedIn;
        }

        public List<CheckIn> GetCheckInsBetweenDates(DateTime startTime, DateTime endTime)
        {
            List<CheckIn> checkIns = new List<CheckIn>(0);
            string query = $"SELECT * FROM CheckIns WHERE CheckInTime>='{startTime}' AND CheckOutTime<='{endTime}'";
            DataSet resultSet = Execute(query);
            DataTable CheckInTable = resultSet.Tables[0];
            foreach (DataRow CheckInRow in CheckInTable.Rows)
            {
                int id = (int)CheckInRow["Id"];
                int employee = (int)CheckInRow["Employee"];
                DateTime lastName = (DateTime)CheckInRow["CheckInTime"];
                DateTime checkOutTime = (DateTime)CheckInRow["CheckOutTime"];
                int absence = (int)CheckInRow["Absence"];

                CheckIn checkIn = new CheckIn();
                checkIns.Add(checkIn);
            }
            return checkIns;
        }
    }
}
