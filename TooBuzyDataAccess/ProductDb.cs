using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Transactions;
using TooBuzyDataAccess.Interfaces;
using TooBuzyEntities;

namespace TooBuzyDataAccess
{
    public class ProductDb : ICRUD<Product>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public bool Create(Product entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Creating Product:" + entity.Id + " " + entity.ProductName);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Product (ProductName, Description, Price, ImageUrl, IsDeleted, Stock, MenuId) VALUES (@ProductName, @Description, @Price, @ImageUrl, @IsDeleted, @MenuId)";
                        cmd.Parameters.AddWithValue("ProductName", entity.ProductName);
                        cmd.Parameters.AddWithValue("Description", entity.Description);
                        cmd.Parameters.AddWithValue("Price", entity.Price);
                        cmd.Parameters.AddWithValue("ImageUrl", entity.ImageUrl);
                        cmd.Parameters.AddWithValue("IsDeleted", entity.IsDeleted);
                        cmd.Parameters.AddWithValue("Stock", entity.Stock);
                        cmd.Parameters.AddWithValue("MenuId", entity.MenuId);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                scope.Complete();
            }
            return true;
        }
        //skal ændres til et update statement så isdeleted bliver benyttet
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
                    Console.WriteLine("Deleting Product by inserted id" + Id);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Product WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", Id);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                scope.Complete();
            }
            return true;
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, ProductName, Description, Price, ImageUrl, IsDeleted, Stock, MenuId FROM Product";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                            product.Description = reader.GetString(reader.GetOrdinal("Description"));
                            product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                            product.ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"));
                            product.IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
                            product.Stock = reader.GetInt32(reader.GetOrdinal("Stock"));
                            product.MenuId = reader.GetInt32(reader.GetOrdinal("MenuId"));
                            products.Add(product);
                        }
                    }
                    connection.Close();
                }
                scope.Complete();
            }
            return products;
        }

        public Product GetById(int Id)
        {
            Product product = new Product();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting Products by inserted id: " + Id);
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, ProductName, Description, Price, ImageUrl, IsDeleted, MenuId FROM Product WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", Id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            product.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                            product.Description = reader.GetString(reader.GetOrdinal("Description"));
                            product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                            product.ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"));
                            product.IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
                            product.Stock = reader.GetInt32(reader.GetOrdinal("Stock"));
                            product.MenuId = reader.GetInt32(reader.GetOrdinal("MenuId"));
                        }
                        reader.Close();
                    }
                    using (SqlCommand olCmd = connection.CreateCommand())
                    {
                        olCmd.CommandText = "SELECT Id, SubTotal, Quantity, ProductId FROM OrderLine WHERE ProductId = @ProductId";
                        olCmd.Parameters.AddWithValue("ProductId", Id);
                        SqlDataReader reader = olCmd.ExecuteReader();
                        while (reader.Read())
                        {
                            product.Orderlines.Add(
                                new OrderLine
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                    SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal")),
                                    OrderId = reader.GetInt32(reader.GetOrdinal("OrderId"))
                                });
                        }
                    }
                    connection.Close();
                }
                scope.Complete();
            }
            return product;
        }

        public bool Update(Product entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Updatting Product:" + entity.ProductName);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Consumer SET ProductName = @ProductName, Description = @Description, Price = @Price, ImageUrl = @ImageUrl, IsDeleted = @IsDeleted, Stock = @Stock, MenuId = @MenuId WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", entity.Id);
                        cmd.Parameters.AddWithValue("ProductName", entity.ProductName);
                        cmd.Parameters.AddWithValue("Desciption", entity.Description);
                        cmd.Parameters.AddWithValue("Price", entity.Price);
                        cmd.Parameters.AddWithValue("ImageUrl", entity.ImageUrl);
                        cmd.Parameters.AddWithValue("IsDeleted", entity.IsDeleted);
                        cmd.Parameters.AddWithValue("Stock", entity.Stock);
                        cmd.Parameters.AddWithValue("MenuId", entity.MenuId);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Product updated");
                    Console.WriteLine("----------------");
                    connection.Close();
                }
                scope.Complete();
            }
            return true;
        }
    }
}
