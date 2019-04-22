using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TooBuzyDataAccess.Interfaces;
using TooBuzyEntities;

namespace TooBuzyDataAccess
{
    public class CustomerDb : ICRUD<Customer>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public void Create(Customer entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Creating customer:" + entity.Name + " " + entity.Address);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INFO Customer (Name, Type, ZipCode, Address, PhoneNo, Password) VALUES(@Name, @Type, @ZipCode, @Address, @PhoneNo, @Password)";
                        cmd.Parameters.AddWithValue("Name", entity.Name);
                        cmd.Parameters.AddWithValue("Type", entity.Type);
                        cmd.Parameters.AddWithValue("ZipCode", entity.ZipCode);
                        cmd.Parameters.AddWithValue("Address", entity.Address);
                        cmd.Parameters.AddWithValue("PhoneNo", entity.PhoneNo);
                        cmd.Parameters.AddWithValue("Password", entity.Password);
                    }
                    Console.WriteLine("Customer created");
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
        }

        public void Delete(int Id)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Customer WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Connection = connection;
                        connection.Open();

                        Console.WriteLine("----------------");
                        Console.WriteLine("Deleting Customer by inserted id" + Id);

                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    Console.WriteLine("Customer deleted!" + Id);
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
        }
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting all Customers");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, Type, ZipCode, Address, PhoneNo FROM Customer";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Customer cus = new Customer();
                            cus.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            cus.Name = reader.GetString(reader.GetOrdinal("Name"));
                            cus.Type = reader.GetString(reader.GetOrdinal("Type"));
                            cus.ZipCode = reader.GetInt32(reader.GetOrdinal("ZipCode"));
                            cus.Address = reader.GetString(reader.GetOrdinal("Address"));
                            cus.PhoneNo = reader.GetInt32(reader.GetOrdinal("PhoneNo"));
                            customers.Add(cus);
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning all Customers");
                    Console.WriteLine("----------------");
                }
                scope.Complete();
            }
            return customers;
        }

        public Customer GetById(int Id)
        {
            Customer customer = new Customer();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting all Customers");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, Type, ZipCode, Address, PhoneNo FROM Customer WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", Id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            customer.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            customer.Name = reader.GetString(reader.GetOrdinal("Name"));
                            customer.Type = reader.GetString(reader.GetOrdinal("Type"));
                            customer.ZipCode = reader.GetInt32(reader.GetOrdinal("ZipCode"));
                            customer.Address = reader.GetString(reader.GetOrdinal("Address"));
                            customer.PhoneNo = reader.GetInt32(reader.GetOrdinal("PhoneNo"));
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning the Customer with id: " + Id);
                    Console.WriteLine("----------------");

                }
            }
            return customer;
        }

        public Customer GetByInt(int phone)
        {
            Customer customer = new Customer();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting all Customers");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, Type, ZipCode, Address, PhoneNo FROM Customer WHERE PhoneNo = @PhoneNo";
                        cmd.Parameters.AddWithValue("@PhoneNo", phone);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            customer.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            customer.Name = reader.GetString(reader.GetOrdinal("Name"));
                            customer.Type = reader.GetString(reader.GetOrdinal("Type"));
                            customer.ZipCode = reader.GetInt32(reader.GetOrdinal("ZipCode"));
                            customer.Address = reader.GetString(reader.GetOrdinal("Address"));
                            customer.PhoneNo = reader.GetInt32(reader.GetOrdinal("PhoneNo"));
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning the Customer with id: " + phone);
                    Console.WriteLine("----------------");

                }
            }
            return customer;
        }

        public void Update(Customer entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Updatting Customer:" + entity.Name);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Customer SET Name = @Name, Type = @Type, ZipCode = @ZipCode, Address = @Address, PhoneNo = @PhoneNo, Password = @Password WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", entity.Id);
                        cmd.Parameters.AddWithValue("Name", entity.Name);
                        cmd.Parameters.AddWithValue("Type", entity.Type);
                        cmd.Parameters.AddWithValue("ZipCode", entity.ZipCode);
                        cmd.Parameters.AddWithValue("Address", entity.Address);
                        cmd.Parameters.AddWithValue("PhoneNo", entity.PhoneNo);
                        cmd.Parameters.AddWithValue("Password", entity.Password);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("customer updated");
                    Console.WriteLine("----------------");
                    connection.Close();
                }
                scope.Complete();
            }
        }
    }
}
