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
    public class TableDb : ICRUD<Table>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public bool Create(Table entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Creating Table:" + " " + entity.CustomerId + " " + entity.TableNo);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO [Table] (TableNo, NoOfSeats, BookingId, CustomerId) VALUES (@TableNo, @NoOfSeats, @BookingId, @CustomerId)";
                        cmd.Parameters.AddWithValue("TableNo", entity.TableNo);
                        cmd.Parameters.AddWithValue("NoOfSeats", entity.NoOfSeats);
                        cmd.Parameters.AddWithValue("CustomerId", entity.CustomerId);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Table created");
                    Console.WriteLine("----------------");

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
                    Console.WriteLine("Deleting Consumer by inserted id" + Id);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Table WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", Id);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("Table deleted!" + Id);
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
            return true;
        }

        public IEnumerable<Table> GetAll()
        {
            List<Table> tables = new List<Table>();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting all Tables");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, TableNo, NoOfSeats, CustomerId FROM [Table]";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Table table = new Table();
                            table.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            table.TableNo = reader.GetInt32(reader.GetOrdinal("TableNo"));
                            table.NoOfSeats = reader.GetInt32(reader.GetOrdinal("NoOfSeats"));
                            table.CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
                            tables.Add(table);
                        }
                    }
                    Console.WriteLine("Returning all Tables");
                    Console.WriteLine("----------------");
                    connection.Close();
                }
                scope.Complete();
            }
            return tables;
        }

        public Table GetById(int Id)
        {
            Table table = new Table();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting all Tables");

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, TableNo, NoOfSeats, BookingId, CustomerId FROM [Table]";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            table.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            table.TableNo = reader.GetInt32(reader.GetOrdinal("TableNo"));
                            table.NoOfSeats = reader.GetInt32(reader.GetOrdinal("NoOfSeats"));
                            table.CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning all Tables");
                    Console.WriteLine("----------------");
                }
                scope.Complete();
            }
            return table;
        }
        public bool Update(Table entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Updatting Table:" + entity.TableNo );

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE [Table] SET TableNo = @TableNo, NoOfSeats = @NoOfSeats, BookingId = @BookingId, CustomerId = @CustomerId WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("TableNo", entity.TableNo);
                        cmd.Parameters.AddWithValue("NoOfSeats", entity.NoOfSeats);
                        cmd.Parameters.AddWithValue("CustomerId", entity.CustomerId);
                    }
                    connection.Close();
                    Console.WriteLine("Table updated");
                    Console.WriteLine("----------------");
                }
                scope.Complete();
            }
            return true;
        }
    }
}
