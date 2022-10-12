using API.D2hClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API.D2hClassLibrary.Operations
{
    public class CustomerOperations
    {
        private static string _connectionString = "Data Source=LAPTOP-QQJKA00R;Initial Catalog=Sapna;Integrated Security=True";
        public static List<Customer> CustomerWithNameAndMultiplePackages(string packages, string name)
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {


                SqlCommand command = new SqlCommand($"EXECUTE [dbo].[CustomerWithMultiplePackages] '{packages}','{name}'", connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer c = new Customer();
                    c.id = (int)reader[0];
                    c.FirstName = (string)reader[1];
                    c.LastName = (string)reader[2];
                    c.Username = (string)reader[3];
                    c.Password = (string)reader[4];
                    c.ConnectionStatus = (int)reader[5];
                    c.PackageId = (int)reader[6];
                    c.GroupId = (int)reader[7];
                    c.AreaId = (int)reader[8];
                    customers.Add(c);

                }

                connection.Close();
            }
            return customers;

        }

        public static List<Package> GetAllPackages()
        {
            List<Package> packages = new List<Package>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {


                SqlCommand command = new SqlCommand($"SELECT P.[id], P.[Package] FROM [Package] as P", connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Package p = new Package();
                    p.Id = (int)reader[0];
                    p.Name = (string)reader[1];
                   
                    packages.Add(p);

                }

                connection.Close();
            }
            return packages;
        }
    }
}
