  using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TooBuzyEntities;

namespace TooBuzyServices
{
    //Opdel hver entitie i hver deres service?
    [ServiceContract]
    public interface ITooBuzyService
    {
        //Consumer CRUD
        [OperationContract]
        bool CreateConsumer(Consumer consumer);
        [OperationContract]
        Consumer GetConsumerById(int Id);
        [OperationContract]
        IEnumerable<Consumer> GetAll();
        [OperationContract]
        bool UpdateConsumer(Consumer consumer);
        [OperationContract]
        bool DeleteConsumer(int Id);
        [OperationContract]
        Consumer GetByInt(int phone);

        //Customer CRUD
        [OperationContract]
        bool CreateCustomer(Customer customer);
        [OperationContract]
        Customer GetCustomerById(int Id);
        [OperationContract]
        Customer GetCustomerByPhone(int phone);
        [OperationContract]
        IEnumerable<Customer> GetAllCustomers();
        [OperationContract]
        bool UpdateCustomer(Customer customer);
        [OperationContract]
        bool DeleteCustomer(int Id);

        //Product CRUD
        [OperationContract]
        bool CreateProduct(Product product);
        [OperationContract]
        Product GetProductById(int Id);
        [OperationContract]
        IEnumerable<Product> GetAllProducts();
        [OperationContract]
        bool UpdateProduct(Product product);
        [OperationContract]
        bool DeleteProduct(int Id);

        //Booking CRUD
        [OperationContract]
        bool CreateBooking(Booking booking);
        [OperationContract]
        Booking GetBookingById(int Id);
        [OperationContract]
        IEnumerable<Booking> GetAllBookings();
        [OperationContract]
        bool UpdateBooking(Booking booking);
        [OperationContract]
        bool DeleteBooking(int Id);

        //Menu CRUD
        [OperationContract]
        bool CreateMenu(Menu menu);
        [OperationContract]
        Menu GetMenuById(int Id);
        [OperationContract]
        IEnumerable<Menu> GetAllMenus();
        [OperationContract]
        bool UpdateMenu(Menu menu);
        [OperationContract]
        bool DeleteMenu(int Id);

        //Order CRUD
        [OperationContract]
        bool CreateOrder(Order order);
        [OperationContract]
        Order GetOrderById(int Id);
        [OperationContract]
        IEnumerable<Order> GetAllOrders();
        [OperationContract]
        bool UpdateOrder(Order order);
        [OperationContract]
        bool DeleteOrder(int Id);

        //Table CRUD
        [OperationContract]
        bool CreateTable(Table table);
        [OperationContract]
        Table GetTableById(int Id);
        [OperationContract]
        IEnumerable<Table> GetAllTables();
        [OperationContract]
        bool UpdateTable(Table table);
        [OperationContract]
        bool DeleteTable(int Id);
    }
}
