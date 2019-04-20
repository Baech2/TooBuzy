using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Transactions;
using System.Data.SqlClient;
using TooBuzyEntities;
using TooBuzyDataAccess.Interfaces;

namespace TooBuzyDataAccess
{
    public class ProductDb : ICRUD<Product>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public void Create(Product entity)
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
                        cmd.CommandText = "INSERT INTO Product (ProductName, Desciption, Price, ImageUrl, IsDeleted, MenuId, OrderLineId) VALUES (@ProductName, @Desciption, @Price, @ImageUrl, @IsDeleted, @MenuId, @OrderLineId)";
                        cmd.Parameters.AddWithValue("ProductName", entity.ProductName);
                        cmd.Parameters.AddWithValue("Desciption", entity.Desciption);
                        cmd.Parameters.AddWithValue("Price", entity.Price);
                        cmd.Parameters.AddWithValue("ImageUrl", entity.ImageUrl);
                        cmd.Parameters.AddWithValue("IsDeleted", entity.IsDeleted);
                        cmd.Parameters.AddWithValue("MenuId", entity.MenuId);
                        cmd.Parameters.AddWithValue("OrderLineId", entity.OrderLineId);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                scope.Complete();
            }
        }
        //skal ændres til et update statement så isdeleted bliver benyttet
        public void Delete(int Id)
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
                        cmd.CommandText = "SELECT Id, ProductName, Desciption, Price, ImageUrl, IsDeleted, MenuId, OrderLineId FROM Product";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                            product.Desciption = reader.GetString(reader.GetOrdinal("Description"));
                            product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                            product.ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"));
                            product.IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
                            product.MenuId = reader.GetInt32(reader.GetOrdinal("MenuId"));
                            product.OrderLineId = reader.GetInt32(reader.GetOrdinal("OrderLineId"));
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
                        cmd.CommandText = "SELECT Id, ProductName, Desciption, Price, ImageUrl, IsDeleted, MenuId, OrderLineId FROM Product WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", Id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            product.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                            product.Desciption = reader.GetString(reader.GetOrdinal("Description"));
                            product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                            product.ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"));
                            product.IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
                            product.MenuId = reader.GetInt32(reader.GetOrdinal("MenuId"));
                            product.OrderLineId = reader.GetInt32(reader.GetOrdinal("OrderLineId"));
                        }
                    }
                    connection.Close();
                }
                scope.Complete();
            }
            return product;
        }

        public Product GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
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
                        cmd.CommandText = "UPDATE Consumer SET ProductName = @ProductName, Desciption = @Desciption, Price = @Price, ImageUrl = @ImageUrl, IsDeleted = @IsDeleted, MenuId = @MenuId, OrderLineId = @OrderLineId WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", entity.Id);
                        cmd.Parameters.AddWithValue("ProductName", entity.ProductName);
                        cmd.Parameters.AddWithValue("Desciption", entity.Desciption);
                        cmd.Parameters.AddWithValue("Price", entity.Price);
                        cmd.Parameters.AddWithValue("ImageUrl", entity.ImageUrl);
                        cmd.Parameters.AddWithValue("IsDeleted", entity.IsDeleted);
                        cmd.Parameters.AddWithValue("MenuId", entity.MenuId);
                        cmd.Parameters.AddWithValue("OrderLineId", entity.OrderLineId);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Product updated");
                    Console.WriteLine("----------------");
                    connection.Close();
                }
                scope.Complete();
            }
        }
    }
}
