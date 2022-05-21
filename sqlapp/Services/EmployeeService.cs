using sqlapp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace sqlapp.Services
{
    public class EmployeeService
    {
        private static string db_source = "demodbsqlserverdjay.database.windows.net";
        private static string user = "dhananjay.mishra";
        private static string password = "Jan@2023";
        private static string database = "demodb";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = user;
            _builder.Password = password;
            _builder.InitialCatalog = database;
            return new SqlConnection(_builder.ConnectionString);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployee(string connectionString)
        {
            List<Employee> employees = new List<Employee>();
            string cmd="Select * from Employee";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand sqlcmd = new SqlCommand(cmd,conn);
            using (SqlDataReader reader= sqlcmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Employee empl = new Employee()
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeID"]),
                        EmployeeName = Convert.ToString(reader["EmployeeName"])
                    };
                    employees.Add(empl);

                }
            }
            return employees;

            
        }
    }
}
