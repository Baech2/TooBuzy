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
    public class OrderLineDb : ICRUD<OrderLine>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public void Create(OrderLine entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Creating OrderLine:" + entity.OrderId + " " + entity.SubTotal);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO OrderLine (Quantity, SubTotal, OrderId) VALUES (@Quantity, @SubTotal, @OrderId)";
                        cmd.Parameters.AddWithValue("Quantity", entity.Quantity);
                        cmd.Parameters.AddWithValue("SubTotal", entity.SubTotal);
                        cmd.Parameters.AddWithValue("OrderId", entity.OrderId);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("OrderLine created");
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
                    Console.WriteLine("Deleting OrderLine by inserted id" + Id);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM OrderLine WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", Id);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("OrderLine deleted!" + Id);
                    Console.WriteLine("----------------");
                }
                scope.Complete();
            }
        }

        public IEnumerable<OrderLine> GetAll()
        {
            List<OrderLine> orderlines = new List<OrderLine>();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting all Consumer");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Quantity, SubTotal, OrderId FROM OrderLine";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            OrderLine orderline = new OrderLine();
                            orderline.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            orderline.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                            orderline.SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal"));
                            orderline.OrderId = reader.GetInt32(reader.GetOrdinal("OrderId"));
                            orderlines.Add(orderline);
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning all OrderLines");
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
            return orderlines;
        }

        public OrderLine GetById(int Id)
        {
            OrderLine orderline = new OrderLine();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting OrderLine by inserted Id:" + Id);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Quantity, SubTotal, OrderId FROM OrderLine";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            orderline.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            orderline.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                            orderline.SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal"));
                            orderline.OrderId = reader.GetInt32(reader.GetOrdinal("OrderId"));
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning OrderLine:" + Id);
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
            return orderline;
        }

        public OrderLine GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderLine entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Updatting OrderLine:" + entity.OrderId + entity.SubTotal);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE OrderLine SET Quantity = @Quantity, SubTotal = @SubTotal, OrderId = @OrderId WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", entity.Id);
                        cmd.Parameters.AddWithValue("Quantity", entity.Quantity);
                        cmd.Parameters.AddWithValue("SubTotal", entity.SubTotal);
                        cmd.Parameters.AddWithValue("OrderId", entity.OrderId);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("OrderLine updated");
                    Console.WriteLine("----------------");
                }
                scope.Complete();
            }
        }
}
