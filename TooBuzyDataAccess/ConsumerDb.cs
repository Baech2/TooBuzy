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
    public class ConsumerDb : ICRUD<Consumer>, IConsumer
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public bool Create(Consumer entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Creating consumer:" + entity.Name + " " + entity.PhoneNo);
                    int insertedId;

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Name FROM Consumer WHERE Name = @Name";
                        cmd.Parameters.AddWithValue("Name", entity.Name);
                        System.Data.DataSet ds = new System.Data.DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        bool fail = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                        if (fail)
                        {
                            Console.WriteLine("Username already exists");
                            return false;
                        }
                        else
                        {

                            using (SqlCommand Ccmd = connection.CreateCommand())
                            {
                                Ccmd.CommandText = "INSERT INTO Consumer (Name, PhoneNo, Password) OUTPUT INSERTED.Id VALUES (@Name, @PhoneNo, @Password)";
                                Ccmd.Parameters.AddWithValue("Name", entity.Name);
                                Ccmd.Parameters.AddWithValue("PhoneNo", entity.PhoneNo);
                                Ccmd.Parameters.AddWithValue("Password", entity.Password);
                                insertedId = (int)Ccmd.ExecuteScalar();
                            }
                            foreach (Booking bk in entity.Bookings)
                            {
                                using (SqlCommand bkcmd = connection.CreateCommand())
                                {
                                    bkcmd.CommandText = "SELECET Id, Date, ConsumerId, TableId FROM Consumer WHERE ConsumerId = @ConsumerId";
                                    bkcmd.Parameters.AddWithValue("Id", bk.Id);
                                    bkcmd.Parameters.AddWithValue("Date", bk.Date);
                                    bkcmd.Parameters.AddWithValue("ConsumerId", insertedId);
                                    bkcmd.Parameters.AddWithValue("TableId", bk.TableId);
                                    bkcmd.ExecuteNonQuery();
                                }
                            }
                            Console.WriteLine("Consumer created");
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
                        cmd.CommandText = "DELETE FROM Consumer WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", Id);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("Consumer deleted!" + Id);
                    Console.WriteLine("----------------");
                }
                scope.Complete();
            }
            return true;
        }

        public IEnumerable<Consumer> GetAll()
        {
            List<Consumer> consumers = new List<Consumer>();
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
                        cmd.CommandText = "SELECT Id, Name, PhoneNo FROM Consumer";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Consumer cons = new Consumer();
                            cons.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            cons.Name = reader.GetString(reader.GetOrdinal("Name"));
                            cons.PhoneNo = reader.GetInt32(reader.GetOrdinal("PhoneNo"));
                            consumers.Add(cons);
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning all Consumers");
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
            return consumers;
        }

        public Consumer GetById(int Id)
        {
            Consumer consumer = new Consumer();
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Getting Consumer by inserted id: " + Id);
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, PhoneNo FROM Consumer WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("Id", Id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            consumer.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            consumer.Name = reader.GetString(reader.GetOrdinal("Name"));
                            consumer.PhoneNo = reader.GetInt32(reader.GetOrdinal("PhoneNo"));
                        }
                        reader.Close();
                    }
                    using (SqlCommand BCmd = connection.CreateCommand())
                    {
                        BCmd.CommandText = "SELECT Id, Date, ConsumerId FROM Booking WHERE ConsumerId = @ConsumerId";
                        BCmd.Parameters.AddWithValue("ConsumerId", Id);
                        SqlDataReader reader = BCmd.ExecuteReader();
                        while (reader.Read())
                        {
                            consumer.Bookings.Add(
                                new Booking
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                    TableId = reader.GetInt32(reader.GetOrdinal("TableId"))
                                });
                        }
                    }
                    connection.Close();
                    Console.WriteLine("Returning the Consumer with id: " + Id + consumer.Bookings.ToList().Count());
                    Console.WriteLine("----------------");
                }
                scope.Complete();
            }
            return consumer;
        }

        public Consumer GetByInt(int phone)
        {
            Consumer consumer = new Consumer();
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
                            consumer.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            consumer.Name = reader.GetString(reader.GetOrdinal("Name"));
                            consumer.PhoneNo = reader.GetInt32(reader.GetOrdinal("PhoneNo"));
                            consumer.Password = reader.GetString(reader.GetOrdinal("Password"));
                        }
                        reader.Close();
                    }
                    using (SqlCommand bCmd = connection.CreateCommand())
                    {
                        bCmd.CommandText = "SELECT Id, Date, ConsumerId FROM Booking WHERE ConsumerId = @ConsumerId";
                        bCmd.Parameters.AddWithValue("ConsumerId", consumer.Id);
                        SqlDataReader reader = bCmd.ExecuteReader();
                        while (reader.Read())
                        {
                            consumer.Bookings.Add(new Booking
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date"))
                            });
                        }
                        reader.Close();
                    }
                    connection.Close();
                    Console.WriteLine("Returning the Customer with id: " + phone);
                    Console.WriteLine("----------------");
                }
                scope.Complete();
            }
            return consumer;
        }

        public bool Login(string Name, string Password)
        {
            throw new NotImplementedException();
        }

        public bool Update(Consumer entity)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Updatting consumer:" + entity.Name);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Consumer SET PhoneNo = @PhoneNo, Password = @Password WHERE Name = @Name";
                        cmd.Parameters.AddWithValue("Name", entity.Name);
                        cmd.Parameters.AddWithValue("PhoneNo", entity.PhoneNo);
                        cmd.Parameters.AddWithValue("Password", entity.Password);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("consumer updated");
                    Console.WriteLine("----------------");
                }
                scope.Complete();
            }
            return true;
        }
    }
}
