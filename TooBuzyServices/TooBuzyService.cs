using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TooBuzyEntities;
using TooBuzyServices;
using TooBuzyDataAccess;
using TooBuzyBusinessLogic;
using System.ServiceModel;
using System.Threading;

namespace TooBuzyServices
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class TooBuzyService : ITooBuzyService
    {
        private BookingController bookCtr = new BookingController();
        private ConsumerController ConsCtr = new ConsumerController();
        private CustomerContoller cusCtr = new CustomerContoller();
        private MenuController menuCtr = new MenuController();
        private OrderController ordCtr = new OrderController();
        private ProductController prodCtr = new ProductController();
        private TableController tabCtr = new TableController();
        
        //Create
        #region
        [OperationBehavior]
        public bool CreateBooking(Booking booking)
        {
            return bookCtr.Create(booking);
        }

        [OperationBehavior(TransactionScopeRequired =true)]
        public bool CreateConsumer(Consumer consumer)
        {
            return ConsCtr.Create(consumer);
        }
        [OperationBehavior]
        public bool CreateCustomer(Customer customer)
        {
            return cusCtr.Create(customer);
        }
        [OperationBehavior]
        public bool CreateMenu(Menu menu)
        {
            return menuCtr.Create(menu);
        }
        [OperationBehavior]
        public bool CreateOrder(Order order)
        {
            return ordCtr.Create(order);
        }
        [OperationBehavior]
        public bool CreateProduct(Product product)
        {
            return prodCtr.Create(product);
        }
        [OperationBehavior]
        public bool CreateTable(Table table)
        {
            return tabCtr.Create(table);
        }
        #endregion

        //Delete
        #region
        [OperationBehavior]
        public bool DeleteBooking(int Id)
        {
            throw new NotImplementedException();
        }

        [OperationBehavior]
        public bool DeleteConsumer(int Id)
        {
            return ConsCtr.Delete(Id);
        }
        [OperationBehavior]
        public bool DeleteCustomer(int Id)
        {
            return cusCtr.Delete(Id);
        }
        [OperationBehavior]
        public bool DeleteMenu(int Id)
        {
            return menuCtr.Delete(Id);
        }
        [OperationBehavior]
        public bool DeleteOrder(int Id)
        {
            return ordCtr.Delete(Id);
        }
        [OperationBehavior]
        public bool DeleteProduct(int Id)
        {
            return prodCtr.Delete(Id);
        }
        [OperationBehavior]
        public bool DeleteTable(int Id)
        {
            return tabCtr.Delete(Id);
        }
        #endregion

        //Get All
        #region
        [OperationBehavior]
        public IEnumerable<Consumer> GetAll()
        {
            var principal = Thread.CurrentPrincipal;
            IEnumerable<Consumer> foundConsumers = ConsCtr.GetAll();
            return foundConsumers;
        }
        [OperationBehavior]
        public IEnumerable<Booking> GetAllBookings()
        {
            IEnumerable<Booking> foundbookings = bookCtr.GetAll();
            return foundbookings;
        }
        [OperationBehavior]
        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> foundcustomers = cusCtr.GetAll();
            return foundcustomers;
        }
        [OperationBehavior]
        public IEnumerable<Menu> GetAllMenus()
        {
            IEnumerable<Menu> foundmenus = menuCtr.GetAll();
            return foundmenus;
        }
        [OperationBehavior]
        public IEnumerable<Order> GetAllOrders()
        {
            IEnumerable<Order> foundorders = ordCtr.GetAll();
            return foundorders;
        }
        [OperationBehavior]
        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> foundproducts = prodCtr.GetAll();
            return foundproducts;
        }
        [OperationBehavior]
        public IEnumerable<Table> GetAllTables()
        {
            IEnumerable<Table> foundtables = tabCtr.GetAll();
            return foundtables;
        }
        #endregion

        //Get by id & phone
        #region
        [OperationBehavior]
        public Booking GetBookingById(int Id)
        {
            return bookCtr.GetById(Id);
        }
        [OperationBehavior]
        public Consumer GetByInt(int phone)
        {
            return ConsCtr.GetByInt(phone);
        }
        [OperationBehavior]
        public Consumer GetConsumerById(int Id)
        {
            return ConsCtr.GetById(Id);
        }
        [OperationBehavior]
        public Customer GetCustomerById(int Id)
        {
            return cusCtr.GetById(Id);
        }
        [OperationBehavior]
        public Customer GetCustomerByPhone(int phone)
        {
            return cusCtr.GetByInt(phone);
        }
        [OperationBehavior]
        public Menu GetMenuById(int Id)
        {
            return menuCtr.GetById(Id);
        }
        [OperationBehavior]
        public Order GetOrderById(int Id)
        {
            return ordCtr.GetById(Id);
        }
        [OperationBehavior]
        public Product GetProductById(int Id)
        {
            return prodCtr.GetById(Id);
        }
        [OperationBehavior]
        public Table GetTableById(int Id)
        {
            return tabCtr.GetById(Id);
        }
        #endregion

        //Update
        #region
        [OperationBehavior]
        public bool UpdateBooking(Booking booking)
        {
            return bookCtr.Update(booking);
        }
        [OperationBehavior]
        public bool UpdateConsumer(Consumer consumer)
        {
            return ConsCtr.Update(consumer);
        }
        [OperationBehavior]
        public bool UpdateCustomer(Customer customer)
        {
            return cusCtr.Update(customer);
        }
        [OperationBehavior]
        public bool UpdateMenu(Menu menu)
        {
            return menuCtr.Update(menu);
        }
        [OperationBehavior]
        public bool UpdateOrder(Order order)
        {
            return ordCtr.Update(order);
        }
        [OperationBehavior]
        public bool UpdateProduct(Product product)
        {
            return prodCtr.Update(product);
        }
        [OperationBehavior]
        public bool UpdateTable(Table table)
        {
            return tabCtr.Update(table);
        }
        #endregion
    }
}
