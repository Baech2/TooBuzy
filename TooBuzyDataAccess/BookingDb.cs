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

        public void Create(Booking entity)
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
                        cmd.CommandText = "INSERT INTO Booking (Date, ConsumerId) VALUES (@Date, @ConsumerId)";
                        cmd.Parameters.AddWithValue("Date", entity.Date);
                        cmd.Parameters.AddWithValue("ConsumerId", entity.ConsumerId);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("Booking created");
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
                        cmd.CommandText = "SELECT Id, Date, ConsumerId FROM Booking";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            booking.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                            booking.ConsumerId = reader.GetInt32(reader.GetOrdinal("ConsumerId"));
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
                        cmd.CommandText = "SELECT Id, Date, ConsumerId FROM Booking";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            booking.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            booking.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                            booking.ConsumerId = reader.GetInt32(reader.GetOrdinal("ConsumerId"));
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

        public Booking GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(Booking entity)
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
                        cmd.CommandText = "UPDATE Consumer SET Date = @Date, ConsumerId = @ConsumerId WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Date", entity.Date);
                        cmd.Parameters.AddWithValue("ConsumerId", entity.ConsumerId);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("Booking updated");
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
        }
    }
}
