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
    public class BookingDb : ICRUD<Booking>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public bool Create(Booking entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Creating Booking:" + entity.Date + " " + entity.ConsumerId);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Booking (Date, ConsumerId, TableId) VALUES (@Date, @ConsumerId, @TableId)";
                        cmd.Parameters.AddWithValue("Date", entity.Date);
                        cmd.Parameters.AddWithValue("ConsumerId", entity.ConsumerId);
                        cmd.Parameters.AddWithValue("TableId", entity.TableId);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("Booking created");
                    Console.WriteLine("----------------");

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
                    Console.WriteLine("Deleting Booking by inserted id" + Id);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Booking WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", Id);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("Booking deleted" + Id);
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
            return true;
        }
        public IEnumerable<Booking> GetAll()
        {
            List<Booking> bookings = new List<Booking>();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting all Bookings");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Date, ConsumerId, TableId FROM Booking";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            booking.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                            booking.ConsumerId = reader.GetInt32(reader.GetOrdinal("ConsumerId"));
                            booking.TableId = reader.GetInt32(reader.GetOrdinal("TableId"));
                            bookings.Add(booking);
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning all bookings");
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
            return bookings;
        }
        public Booking GetById(int Id)
        {
            Booking booking = new Booking();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting Booking by inserted Id:"+ Id);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Date, ConsumerId, TableId FROM Booking";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            booking.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            booking.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                            booking.ConsumerId = reader.GetInt32(reader.GetOrdinal("ConsumerId"));
                            booking.TableId = reader.GetInt32(reader.GetOrdinal("TableId"));
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning Booking");
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
            return booking;
        }
        public bool Update(Booking entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Updatting Booking:" + entity.Date + entity.ConsumerId);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Consumer SET Date = @Date, ConsumerId = @ConsumerId, TableId = @TableId WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Date", entity.Date);
                        cmd.Parameters.AddWithValue("ConsumerId", entity.ConsumerId);
                        cmd.Parameters.AddWithValue("TableId", entity.TableId);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("Booking updated");
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
            return true;
        }
    }
}
