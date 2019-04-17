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
    public class ConsumerDb : ICRUD<Consumer>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public void Create(Consumer entity)
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

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Consumer (Name, PhoneNo, Password) VALUES (@Name, @PhoneNo, @Password)";
                        cmd.Parameters.AddWithValue("Name", entity.Name);
                        cmd.Parameters.AddWithValue("PhoneNo", entity.PhoneNo);
                        cmd.Parameters.AddWithValue("Password", entity.Password);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Consumer created");
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

                    string query = "DELETE FROM [Order] WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Connection = connection;
                        connection.Open();
                        Console.WriteLine("----------------");
                        Console.WriteLine("Deleting Consumer by inserted id" + Id);

                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    Console.WriteLine("Consumer deleted!" + Id);
                    Console.WriteLine("----------------");

                }
                scope.Complete();
            }
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
                        cmd.Parameters.AddWithValue("@Id", Id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            consumer.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            consumer.Name = reader.GetString(reader.GetOrdinal("Name"));
                            consumer.PhoneNo = reader.GetInt32(reader.GetOrdinal("PhoneNo"));
                        }
                    }

                    Console.WriteLine("Returning the Consumer with id: " + Id);
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
                    Console.WriteLine("Getting Consumer by inserted phone number:" + phone);

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, Name, PhoneNo FROM Consumer where PhoneNo = @PhoneNo";
                        cmd.Parameters.AddWithValue("PhoneNo", phone);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            consumer.Name = reader.GetString(reader.GetOrdinal("Name"));
                            consumer.PhoneNo = reader.GetInt32(reader.GetOrdinal("PhoneNo"));
                        }
                    }

                    Console.WriteLine("Returning Consumer by inserted phone number: " + phone);
                    Console.WriteLine("----------------");

                }
                scope.Complete();

            }


            return consumer;
        }

        public void Update(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
