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
    public class OrderDb : ICRUD<Order>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public void Create(Order entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.RepeatableRead;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Creating Order:" + entity.Date + " " + entity.TotalPrice);
                    int insertedId;
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO [Order] (TotalPrice, Date, BookingId) OUTPUT INSERTED.ID VALUES (@TotalPrice, @Date, @BookingId)s";
                        cmd.Parameters.AddWithValue("TotalPrice", entity.TotalPrice);
                        cmd.Parameters.AddWithValue("Date", entity.Date);
                        cmd.Parameters.AddWithValue("BookingId", entity.BookingId);
                        insertedId = (int)cmd.ExecuteScalar();
                    }
                    foreach (OrderLine ol in entity.OrderLines)
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "SELCET Stock FROM Product WHERE Id = @Id";
                            cmd.Parameters.AddWithValue("Id", ol.ProductId);
                            var quantityInStock = (int)cmd.ExecuteScalar();
                            if (quantityInStock < ol.Quantity)
                            {
                                throw new Exception("Not enough products in stock");
                            }
                            else
                            {
                                using (SqlCommand olCmd = connection.CreateCommand())
                                {
                                    olCmd.CommandText = "INSERT INTO Orderline (Quantity, SubTotal, OrderId, ProductId) VALUES (@Quantity, @SubTotal, @OrderId, @ProductId)";
                                    olCmd.Parameters.AddWithValue("Quantity", ol.Quantity);
                                    olCmd.Parameters.AddWithValue("SubTotal", ol.SubTotal);
                                    olCmd.Parameters.AddWithValue("OrderId", insertedId);
                                    olCmd.Parameters.AddWithValue("ProductId", ol.ProductId);
                                    olCmd.ExecuteNonQuery();
                                }

                                using (SqlCommand decrementCmd = connection.CreateCommand())
                                {
                                    decrementCmd.CommandText = "UPDATE Product SET Quantity = @Quantity WHERE Id = @Id";
                                    decrementCmd.Parameters.AddWithValue("Id", ol.ProductId);
                                    decrementCmd.Parameters.AddWithValue("Quantity", ol.Quantity);
                                    decrementCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Order created");
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
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Deleting Order by inserted id" + Id);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM [Order] WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", Id);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("Consumer deleted!" + Id);
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            List<Order> orders = new List<Order>();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, TotalPrice, Date, BookingId FROM [Order]";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            order.TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice"));
                            order.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                            order.BookingId = reader.GetInt32(reader.GetOrdinal("BookingId"));
                            orders.Add(order);
                        }
                        connection.Close();
                    }
                    scope.Complete();
                }
            }
            return orders;
        }

        public Order GetById(int Id)
        {
            Order order = new Order();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting Orders by inserted id: " + Id);
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, TotalPrice, Date, BookingId FROM [Order] WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", Id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            order.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            order.TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice"));
                            order.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                            order.BookingId = reader.GetInt32(reader.GetOrdinal("BookingId"));
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning the Orders with id: " + Id);
                    Console.WriteLine("----------------");
                }
                scope.Complete();
            }
            return order;
        }
        public Order GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Updatting Order:" + entity.Id + entity.TotalPrice + entity.Date);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE [Order] SET TotalPrice = @TotalPrice, Date = @Date, BookingId = @BookingId WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", entity.Id);
                        cmd.Parameters.AddWithValue("TotalPrice", entity.TotalPrice);
                        cmd.Parameters.AddWithValue("Date", entity.Date);
                        cmd.Parameters.AddWithValue("BookingId", entity.BookingId);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Order updated");
                    Console.WriteLine("----------------");
                    connection.Close();
                }
                scope.Complete();
            }
        }
    }
}
