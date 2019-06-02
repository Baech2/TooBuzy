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
    public class CustomerDb : ICRUD<Customer>, ICustomer
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public bool Create(Customer entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.RepeatableRead;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Creating customer:" + entity.Name + " " + entity.Address);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Name FROM Customer WHERE Name = @Name";
                        cmd.Parameters.AddWithValue("Name", entity.Name);
                        System.Data.DataSet ds = new System.Data.DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        bool fail = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                        if (fail)
                        {
                            Console.WriteLine("Customer name already exsists!");
                            return false;
                        }
                        else
                        {
                            using (SqlCommand Ccmd = connection.CreateCommand())
                            {
                                Ccmd.CommandText = "INSERT INTO Customer (Name, Type, ZipCode, Address, PhoneNo, Logo, Createdate, Password, MenuId) VALUES(@Name, @Type, @ZipCode, @Address, @PhoneNo, @Logo, @Createdate, @Password, @MenuId)";
                                Ccmd.Parameters.AddWithValue("Name", entity.Name);
                                Ccmd.Parameters.AddWithValue("Type", entity.Type);
                                Ccmd.Parameters.AddWithValue("ZipCode", entity.ZipCode);
                                Ccmd.Parameters.AddWithValue("Address", entity.Address);
                                Ccmd.Parameters.AddWithValue("PhoneNo", entity.PhoneNo);
                                Ccmd.Parameters.AddWithValue("Logo", entity.Logo);
                                Ccmd.Parameters.AddWithValue("Createdate", entity.Createdate);
                                Ccmd.Parameters.AddWithValue("Password", entity.Password);
                                Ccmd.Parameters.AddWithValue("MenuId", entity.MenuId);
                                Ccmd.ExecuteNonQuery();
                            }
                            Console.WriteLine("Customer created");
                            Console.WriteLine("----------------");
                            connection.Close();
                            scope.Complete();
                            return true;
                        }
                    }
                }
            }
        }

        public bool Delete(int Id)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.RepeatableRead;
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
            return true;
        }
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.RepeatableRead;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting all Customers");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, Type, ZipCode, Address, PhoneNo, Createdate, MenuId FROM Customer";
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
                            cus.Logo = reader.GetString(reader.GetOrdinal("Logo"));
                            cus.Createdate = reader.GetDateTime(reader.GetOrdinal("Createdate"));
                            cus.MenuId = reader.GetInt32(reader.GetOrdinal("MenuId"));
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
            options.IsolationLevel = IsolationLevel.RepeatableRead;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting all Customers");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, Type, ZipCode, Address, PhoneNo, Createdate, MenuId FROM Customer WHERE Id = @Id";
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
                            customer.Logo = reader.GetString(reader.GetOrdinal("Logo"));
                            customer.Createdate = reader.GetDateTime(reader.GetOrdinal("Createdate"));
                            customer.MenuId = reader.GetInt32(reader.GetOrdinal("MenuId"));

                        }
                        reader.Close();
                    }
                    using (SqlCommand Tcmd = connection.CreateCommand())
                    {
                        Tcmd.CommandText = "SELECT Id, TableNo, NoOfSeats, CustomerId FROM [Table] WHERE CustomerId = @CustomerId";
                        Tcmd.Parameters.AddWithValue("CustomerId", Id);
                        SqlDataReader reader = Tcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            customer.Tables.Add(new Table
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                TableNo = reader.GetInt32(reader.GetOrdinal("TableNo")),
                                NoOfSeats = reader.GetInt32(reader.GetOrdinal("NoOfSeats")),
                                CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId"))
                            });
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning the Customer with id: " + Id);
                    Console.WriteLine("----------------");
                }
                scope.Complete();
            }
            return customer;
        }

        public Customer GetByInt(int phone)
        {
            Customer customer = new Customer();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.RepeatableRead;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting all Customers");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, Type, ZipCode, Address, PhoneNo, MenuId FROM Customer WHERE PhoneNo = @PhoneNo";
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
                            customer.Logo = reader.GetString(reader.GetOrdinal("Logo"));
                            customer.MenuId = reader.GetInt32(reader.GetOrdinal("MenuId"));

                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning the Customer with id: " + phone);
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
            return customer;
        }

        public bool Login(string Name, string Password)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadUncommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("------------");
                    Console.WriteLine("Attempting to login a Customer");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, Type, ZipCode, Address, PhoneNo FROM Customer WHERE Name = @Name AND Password = @Password";
                        cmd.Parameters.AddWithValue("Name", Name);
                        cmd.Parameters.AddWithValue("Password", Password);

                        System.Data.DataSet ds = new System.Data.DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        bool Success = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                        if (Success)
                        {
                            //skal håndteres anderledes. Gerne med meddelelse
                            Console.WriteLine("Customer Login Succeded! " + Name);
                            connection.Close();
                            scope.Complete();

                        }
                        else
                        {
                            //Denne exception skal håndres anderledes. Gerne i UI
                            connection.Close();
                            scope.Complete();
                            return false;
                        }
                    }

                }

            }
            return true;
        }

        public bool Update(Customer entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.RepeatableRead;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Updatting Customer:" + entity.Name);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Customer SET Type = @Type, ZipCode = @ZipCode, Address = @Address, PhoneNo = @PhoneNo, Logo = @Logo Password = @Password, MenuId = @MenuId WHERE Name = @Name";
                        cmd.Parameters.AddWithValue("Id", entity.Id);
                        cmd.Parameters.AddWithValue("Name", entity.Name);
                        cmd.Parameters.AddWithValue("Type", entity.Type);
                        cmd.Parameters.AddWithValue("ZipCode", entity.ZipCode);
                        cmd.Parameters.AddWithValue("Address", entity.Address);
                        cmd.Parameters.AddWithValue("PhoneNo", entity.PhoneNo);
                        cmd.Parameters.AddWithValue("Logo", entity.Logo);
                        cmd.Parameters.AddWithValue("Password", entity.Password);
                        cmd.Parameters.AddWithValue("MenuId", entity.MenuId);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("customer updated");
                    Console.WriteLine("----------------");
                    connection.Close();
                }
                scope.Complete();
            }
            return true;
        }
    }
}
