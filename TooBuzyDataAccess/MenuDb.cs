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
    public class MenuDb : ICRUD<Menu>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public bool Create(Menu entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Creating Menu:" + entity.Id + " " + entity.Category);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Menu (Name, Category, Description) VALUES (@Name, @Category, @Description)";
                        cmd.Parameters.AddWithValue("Name", entity.Name);
                        cmd.Parameters.AddWithValue("Category", entity.Category);
                        cmd.Parameters.AddWithValue("Description", entity.Description);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Menu Created");
                    connection.Close();
                }
                scope.Complete();
            }
            return true;
        }
        public bool Delete(int Id)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Deleting menu by inserted id" + Id);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Menu WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", Id);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Deleting Menu by inserted Id:" + Id);
                    Console.WriteLine("----------------");

                    connection.Close();
                }
                scope.Complete();
            }
            return true;
        }

        public IEnumerable<Menu> GetAll()
        {
            List<Menu> menus = new List<Menu>();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting all Menus");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name,  Category, Description FROM Menu";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Menu menu = new Menu();
                            menu.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            menu.Name = reader.GetString(reader.GetOrdinal("Name"));
                            menu.Category = reader.GetString(reader.GetOrdinal("Category"));
                            menu.Description = reader.GetString(reader.GetOrdinal("Description"));
                            menus.Add(menu);
                        }
                    }
                    Console.WriteLine("Returning all Menus");
                    Console.WriteLine("----------------");

                    connection.Close();
                }
                scope.Complete();
            }
            return menus;
        }

        public Menu GetById(int Id)
        {
            Menu menu = new Menu();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting Menu by inserted Id:" + Id);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, Category, Description FROM Menu";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            menu.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            menu.Name = reader.GetString(reader.GetOrdinal("Name"));
                            menu.Category = reader.GetString(reader.GetOrdinal("Category"));
                            menu.Description = reader.GetString(reader.GetOrdinal("Description"));
                        }
                        reader.Close();
                    }
                    using (SqlCommand Mcmd = connection.CreateCommand())
                    {
                        Mcmd.CommandText = "SELECT Id, Name, Description, Price, IsDeleted, MenuId FROM Product WHERE MenuId = @MenuId ";
                        Mcmd.Parameters.AddWithValue("MenuId", Id);
                        SqlDataReader reader = Mcmd.ExecuteReader();
                        while (reader.Read())
                        {
                            menu.Products.Add(new Product
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                                MenuId = reader.GetInt32(reader.GetOrdinal("MenuId"))
                            });
                        }
                    }
                    Console.WriteLine("Returning Menu by inserted Id:" + Id);
                    Console.WriteLine("----------------");

                    connection.Close();
                }
                scope.Complete();
            }
            return menu;
        }

        public bool Update(Menu entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Updatting Menu:" + entity.Category);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Menu SET Category = @Category, Description = @Description, WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", entity.Id);
                        cmd.Parameters.AddWithValue("Category", entity.Category);
                        cmd.Parameters.AddWithValue("Description", entity.Description);
                    }
                    Console.WriteLine("Menu updated");
                    Console.WriteLine("----------------");
                    connection.Close();
                }
                scope.Complete();
            }
            return true;
        }
    }
}
