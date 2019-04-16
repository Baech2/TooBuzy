using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TooBuzyDataAccess.Interfaces;
using TooBuzyEntities;

namespace TooBuzyDataAccess
{
    public class OrderDb : ICRUD<Order>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public void Create(Order entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                //indsætte ordre i databasen

                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Order] (TotalPrice, Date, BookingId) VALUES (@TotalPrice, @Date, @BookingId";
                    cmd.Parameters.AddWithValue("TotalPrice", entity.TotalPrice);
                    cmd.Parameters.AddWithValue("Date", entity.Date);
                    cmd.Parameters.AddWithValue("BookingId", entity.BookingId);
                    cmd.ExecuteNonQuery();
                }
                foreach (OrderLine ol in entity.OrderLines)
                {
                    using(SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO OrderLine (Quantity, SubTotal,OrderId) VALUES (@Quantity, @SubTotal, @OrderId)";
                        cmd.Parameters.AddWithValue("Quantity", ol.Quantity);
                        cmd.Parameters.AddWithValue("SubTotal", ol.SubTotal);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Order GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
