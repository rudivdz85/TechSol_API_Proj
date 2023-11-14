using TechSol_API_Proj.Interfaces;
using TechSol_API_Proj.Models;
using System.Data.SqlClient;

namespace TechSol_API_Proj
{
    public class DatabaseOperations : IDatabaseOperations
    {

        private string connectionString;

        public DatabaseOperations(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddCustomer(string firstName, string lastName, DateTime dateOfBirth)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (FirstName, LastName, DateOfBirth) VALUES (@FirstName, @LastName, @DateOfBirth)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Customer GetCustomer(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer
                        {
                            CustomerId = (int)reader["CustomerID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = (DateTime)reader["DateOfBirth"]
                        };
                    }
                }
            }
            return null;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers";

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var customer = new Customer
                            {
                                CustomerId = (int)reader["CustomerID"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                DateOfBirth = (DateTime)reader["DateOfBirth"]
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }
            return customers;
        }


        public void UpdateCustomer(int customerId, string firstName, string lastName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName WHERE CustomerID = @CustomerID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@CustomerID", customerId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
