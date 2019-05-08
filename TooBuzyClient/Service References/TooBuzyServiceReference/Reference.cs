﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TooBuzyClient.TooBuzyServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TooBuzyServiceReference.ITooBuzyService")]
    public interface ITooBuzyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/CreateConsumerResponse")]
        bool CreateConsumer(TooBuzyEntities.Consumer consumer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/CreateConsumerResponse")]
        System.Threading.Tasks.Task<bool> CreateConsumerAsync(TooBuzyEntities.Consumer consumer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetConsumerById", ReplyAction="http://tempuri.org/ITooBuzyService/GetConsumerByIdResponse")]
        TooBuzyEntities.Consumer GetConsumerById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetConsumerById", ReplyAction="http://tempuri.org/ITooBuzyService/GetConsumerByIdResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Consumer> GetConsumerByIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAll", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllResponse")]
        TooBuzyEntities.Consumer[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAll", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Consumer[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateConsumerResponse")]
        bool UpdateConsumer(TooBuzyEntities.Consumer consumer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateConsumerResponse")]
        System.Threading.Tasks.Task<bool> UpdateConsumerAsync(TooBuzyEntities.Consumer consumer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteConsumerResponse")]
        bool DeleteConsumer(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteConsumerResponse")]
        System.Threading.Tasks.Task<bool> DeleteConsumerAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetByInt", ReplyAction="http://tempuri.org/ITooBuzyService/GetByIntResponse")]
        TooBuzyEntities.Consumer GetByInt(int phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetByInt", ReplyAction="http://tempuri.org/ITooBuzyService/GetByIntResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Consumer> GetByIntAsync(int phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateCustomer", ReplyAction="http://tempuri.org/ITooBuzyService/CreateCustomerResponse")]
        bool CreateCustomer(TooBuzyEntities.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateCustomer", ReplyAction="http://tempuri.org/ITooBuzyService/CreateCustomerResponse")]
        System.Threading.Tasks.Task<bool> CreateCustomerAsync(TooBuzyEntities.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetCustomerById", ReplyAction="http://tempuri.org/ITooBuzyService/GetCustomerByIdResponse")]
        TooBuzyEntities.Customer GetCustomerById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetCustomerById", ReplyAction="http://tempuri.org/ITooBuzyService/GetCustomerByIdResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Customer> GetCustomerByIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetCustomerByPhone", ReplyAction="http://tempuri.org/ITooBuzyService/GetCustomerByPhoneResponse")]
        TooBuzyEntities.Customer GetCustomerByPhone(int phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetCustomerByPhone", ReplyAction="http://tempuri.org/ITooBuzyService/GetCustomerByPhoneResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Customer> GetCustomerByPhoneAsync(int phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllCustomers", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllCustomersResponse")]
        TooBuzyEntities.Customer[] GetAllCustomers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllCustomers", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllCustomersResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Customer[]> GetAllCustomersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateCustomer", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateCustomerResponse")]
        bool UpdateCustomer(TooBuzyEntities.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateCustomer", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateCustomerResponse")]
        System.Threading.Tasks.Task<bool> UpdateCustomerAsync(TooBuzyEntities.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteCustomer", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteCustomerResponse")]
        bool DeleteCustomer(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteCustomer", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteCustomerResponse")]
        System.Threading.Tasks.Task<bool> DeleteCustomerAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateProduct", ReplyAction="http://tempuri.org/ITooBuzyService/CreateProductResponse")]
        bool CreateProduct(TooBuzyEntities.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateProduct", ReplyAction="http://tempuri.org/ITooBuzyService/CreateProductResponse")]
        System.Threading.Tasks.Task<bool> CreateProductAsync(TooBuzyEntities.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetProductById", ReplyAction="http://tempuri.org/ITooBuzyService/GetProductByIdResponse")]
        TooBuzyEntities.Product GetProductById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetProductById", ReplyAction="http://tempuri.org/ITooBuzyService/GetProductByIdResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Product> GetProductByIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllProducts", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllProductsResponse")]
        TooBuzyEntities.Product[] GetAllProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllProducts", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllProductsResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Product[]> GetAllProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateProduct", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateProductResponse")]
        bool UpdateProduct(TooBuzyEntities.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateProduct", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateProductResponse")]
        System.Threading.Tasks.Task<bool> UpdateProductAsync(TooBuzyEntities.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteProduct", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteProductResponse")]
        bool DeleteProduct(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteProduct", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteProductResponse")]
        System.Threading.Tasks.Task<bool> DeleteProductAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateBooking", ReplyAction="http://tempuri.org/ITooBuzyService/CreateBookingResponse")]
        bool CreateBooking(TooBuzyEntities.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateBooking", ReplyAction="http://tempuri.org/ITooBuzyService/CreateBookingResponse")]
        System.Threading.Tasks.Task<bool> CreateBookingAsync(TooBuzyEntities.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetBookingById", ReplyAction="http://tempuri.org/ITooBuzyService/GetBookingByIdResponse")]
        TooBuzyEntities.Booking GetBookingById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetBookingById", ReplyAction="http://tempuri.org/ITooBuzyService/GetBookingByIdResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Booking> GetBookingByIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllBookings", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllBookingsResponse")]
        TooBuzyEntities.Booking[] GetAllBookings();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllBookings", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllBookingsResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Booking[]> GetAllBookingsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateBooking", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateBookingResponse")]
        bool UpdateBooking(TooBuzyEntities.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateBooking", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateBookingResponse")]
        System.Threading.Tasks.Task<bool> UpdateBookingAsync(TooBuzyEntities.Booking booking);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteBooking", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteBookingResponse")]
        bool DeleteBooking(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteBooking", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteBookingResponse")]
        System.Threading.Tasks.Task<bool> DeleteBookingAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateMenu", ReplyAction="http://tempuri.org/ITooBuzyService/CreateMenuResponse")]
        bool CreateMenu(TooBuzyEntities.Menu menu);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateMenu", ReplyAction="http://tempuri.org/ITooBuzyService/CreateMenuResponse")]
        System.Threading.Tasks.Task<bool> CreateMenuAsync(TooBuzyEntities.Menu menu);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetMenuById", ReplyAction="http://tempuri.org/ITooBuzyService/GetMenuByIdResponse")]
        TooBuzyEntities.Menu GetMenuById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetMenuById", ReplyAction="http://tempuri.org/ITooBuzyService/GetMenuByIdResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Menu> GetMenuByIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllMenus", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllMenusResponse")]
        TooBuzyEntities.Menu[] GetAllMenus();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllMenus", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllMenusResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Menu[]> GetAllMenusAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateMenu", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateMenuResponse")]
        bool UpdateMenu(TooBuzyEntities.Menu menu);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateMenu", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateMenuResponse")]
        System.Threading.Tasks.Task<bool> UpdateMenuAsync(TooBuzyEntities.Menu menu);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteMenu", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteMenuResponse")]
        bool DeleteMenu(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteMenu", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteMenuResponse")]
        System.Threading.Tasks.Task<bool> DeleteMenuAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateOrder", ReplyAction="http://tempuri.org/ITooBuzyService/CreateOrderResponse")]
        bool CreateOrder(TooBuzyEntities.Order order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateOrder", ReplyAction="http://tempuri.org/ITooBuzyService/CreateOrderResponse")]
        System.Threading.Tasks.Task<bool> CreateOrderAsync(TooBuzyEntities.Order order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetOrderById", ReplyAction="http://tempuri.org/ITooBuzyService/GetOrderByIdResponse")]
        TooBuzyEntities.Order GetOrderById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetOrderById", ReplyAction="http://tempuri.org/ITooBuzyService/GetOrderByIdResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Order> GetOrderByIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllOrders", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllOrdersResponse")]
        TooBuzyEntities.Order[] GetAllOrders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllOrders", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllOrdersResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Order[]> GetAllOrdersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateOrder", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateOrderResponse")]
        bool UpdateOrder(TooBuzyEntities.Order order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateOrder", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateOrderResponse")]
        System.Threading.Tasks.Task<bool> UpdateOrderAsync(TooBuzyEntities.Order order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteOrder", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteOrderResponse")]
        bool DeleteOrder(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteOrder", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteOrderResponse")]
        System.Threading.Tasks.Task<bool> DeleteOrderAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateTable", ReplyAction="http://tempuri.org/ITooBuzyService/CreateTableResponse")]
        bool CreateTable(TooBuzyEntities.Table table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateTable", ReplyAction="http://tempuri.org/ITooBuzyService/CreateTableResponse")]
        System.Threading.Tasks.Task<bool> CreateTableAsync(TooBuzyEntities.Table table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetTableById", ReplyAction="http://tempuri.org/ITooBuzyService/GetTableByIdResponse")]
        TooBuzyEntities.Table GetTableById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetTableById", ReplyAction="http://tempuri.org/ITooBuzyService/GetTableByIdResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Table> GetTableByIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllTables", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllTablesResponse")]
        TooBuzyEntities.Table[] GetAllTables();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAllTables", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllTablesResponse")]
        System.Threading.Tasks.Task<TooBuzyEntities.Table[]> GetAllTablesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateTable", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateTableResponse")]
        bool UpdateTable(TooBuzyEntities.Table table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateTable", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateTableResponse")]
        System.Threading.Tasks.Task<bool> UpdateTableAsync(TooBuzyEntities.Table table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteTable", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteTableResponse")]
        bool DeleteTable(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteTable", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteTableResponse")]
        System.Threading.Tasks.Task<bool> DeleteTableAsync(int Id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITooBuzyServiceChannel : TooBuzyClient.TooBuzyServiceReference.ITooBuzyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TooBuzyServiceClient : System.ServiceModel.ClientBase<TooBuzyClient.TooBuzyServiceReference.ITooBuzyService>, TooBuzyClient.TooBuzyServiceReference.ITooBuzyService {
        
        public TooBuzyServiceClient() {
        }
        
        public TooBuzyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TooBuzyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TooBuzyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TooBuzyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CreateConsumer(TooBuzyEntities.Consumer consumer) {
            return base.Channel.CreateConsumer(consumer);
        }
        
        public System.Threading.Tasks.Task<bool> CreateConsumerAsync(TooBuzyEntities.Consumer consumer) {
            return base.Channel.CreateConsumerAsync(consumer);
        }
        
        public TooBuzyEntities.Consumer GetConsumerById(int Id) {
            return base.Channel.GetConsumerById(Id);
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Consumer> GetConsumerByIdAsync(int Id) {
            return base.Channel.GetConsumerByIdAsync(Id);
        }
        
        public TooBuzyEntities.Consumer[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Consumer[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public bool UpdateConsumer(TooBuzyEntities.Consumer consumer) {
            return base.Channel.UpdateConsumer(consumer);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateConsumerAsync(TooBuzyEntities.Consumer consumer) {
            return base.Channel.UpdateConsumerAsync(consumer);
        }
        
        public bool DeleteConsumer(int Id) {
            return base.Channel.DeleteConsumer(Id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteConsumerAsync(int Id) {
            return base.Channel.DeleteConsumerAsync(Id);
        }
        
        public TooBuzyEntities.Consumer GetByInt(int phone) {
            return base.Channel.GetByInt(phone);
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Consumer> GetByIntAsync(int phone) {
            return base.Channel.GetByIntAsync(phone);
        }
        
        public bool CreateCustomer(TooBuzyEntities.Customer customer) {
            return base.Channel.CreateCustomer(customer);
        }
        
        public System.Threading.Tasks.Task<bool> CreateCustomerAsync(TooBuzyEntities.Customer customer) {
            return base.Channel.CreateCustomerAsync(customer);
        }
        
        public TooBuzyEntities.Customer GetCustomerById(int Id) {
            return base.Channel.GetCustomerById(Id);
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Customer> GetCustomerByIdAsync(int Id) {
            return base.Channel.GetCustomerByIdAsync(Id);
        }
        
        public TooBuzyEntities.Customer GetCustomerByPhone(int phone) {
            return base.Channel.GetCustomerByPhone(phone);
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Customer> GetCustomerByPhoneAsync(int phone) {
            return base.Channel.GetCustomerByPhoneAsync(phone);
        }
        
        public TooBuzyEntities.Customer[] GetAllCustomers() {
            return base.Channel.GetAllCustomers();
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Customer[]> GetAllCustomersAsync() {
            return base.Channel.GetAllCustomersAsync();
        }
        
        public bool UpdateCustomer(TooBuzyEntities.Customer customer) {
            return base.Channel.UpdateCustomer(customer);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateCustomerAsync(TooBuzyEntities.Customer customer) {
            return base.Channel.UpdateCustomerAsync(customer);
        }
        
        public bool DeleteCustomer(int Id) {
            return base.Channel.DeleteCustomer(Id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteCustomerAsync(int Id) {
            return base.Channel.DeleteCustomerAsync(Id);
        }
        
        public bool CreateProduct(TooBuzyEntities.Product product) {
            return base.Channel.CreateProduct(product);
        }
        
        public System.Threading.Tasks.Task<bool> CreateProductAsync(TooBuzyEntities.Product product) {
            return base.Channel.CreateProductAsync(product);
        }
        
        public TooBuzyEntities.Product GetProductById(int Id) {
            return base.Channel.GetProductById(Id);
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Product> GetProductByIdAsync(int Id) {
            return base.Channel.GetProductByIdAsync(Id);
        }
        
        public TooBuzyEntities.Product[] GetAllProducts() {
            return base.Channel.GetAllProducts();
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Product[]> GetAllProductsAsync() {
            return base.Channel.GetAllProductsAsync();
        }
        
        public bool UpdateProduct(TooBuzyEntities.Product product) {
            return base.Channel.UpdateProduct(product);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateProductAsync(TooBuzyEntities.Product product) {
            return base.Channel.UpdateProductAsync(product);
        }
        
        public bool DeleteProduct(int Id) {
            return base.Channel.DeleteProduct(Id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteProductAsync(int Id) {
            return base.Channel.DeleteProductAsync(Id);
        }
        
        public bool CreateBooking(TooBuzyEntities.Booking booking) {
            return base.Channel.CreateBooking(booking);
        }
        
        public System.Threading.Tasks.Task<bool> CreateBookingAsync(TooBuzyEntities.Booking booking) {
            return base.Channel.CreateBookingAsync(booking);
        }
        
        public TooBuzyEntities.Booking GetBookingById(int Id) {
            return base.Channel.GetBookingById(Id);
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Booking> GetBookingByIdAsync(int Id) {
            return base.Channel.GetBookingByIdAsync(Id);
        }
        
        public TooBuzyEntities.Booking[] GetAllBookings() {
            return base.Channel.GetAllBookings();
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Booking[]> GetAllBookingsAsync() {
            return base.Channel.GetAllBookingsAsync();
        }
        
        public bool UpdateBooking(TooBuzyEntities.Booking booking) {
            return base.Channel.UpdateBooking(booking);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateBookingAsync(TooBuzyEntities.Booking booking) {
            return base.Channel.UpdateBookingAsync(booking);
        }
        
        public bool DeleteBooking(int Id) {
            return base.Channel.DeleteBooking(Id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteBookingAsync(int Id) {
            return base.Channel.DeleteBookingAsync(Id);
        }
        
        public bool CreateMenu(TooBuzyEntities.Menu menu) {
            return base.Channel.CreateMenu(menu);
        }
        
        public System.Threading.Tasks.Task<bool> CreateMenuAsync(TooBuzyEntities.Menu menu) {
            return base.Channel.CreateMenuAsync(menu);
        }
        
        public TooBuzyEntities.Menu GetMenuById(int Id) {
            return base.Channel.GetMenuById(Id);
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Menu> GetMenuByIdAsync(int Id) {
            return base.Channel.GetMenuByIdAsync(Id);
        }
        
        public TooBuzyEntities.Menu[] GetAllMenus() {
            return base.Channel.GetAllMenus();
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Menu[]> GetAllMenusAsync() {
            return base.Channel.GetAllMenusAsync();
        }
        
        public bool UpdateMenu(TooBuzyEntities.Menu menu) {
            return base.Channel.UpdateMenu(menu);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateMenuAsync(TooBuzyEntities.Menu menu) {
            return base.Channel.UpdateMenuAsync(menu);
        }
        
        public bool DeleteMenu(int Id) {
            return base.Channel.DeleteMenu(Id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteMenuAsync(int Id) {
            return base.Channel.DeleteMenuAsync(Id);
        }
        
        public bool CreateOrder(TooBuzyEntities.Order order) {
            return base.Channel.CreateOrder(order);
        }
        
        public System.Threading.Tasks.Task<bool> CreateOrderAsync(TooBuzyEntities.Order order) {
            return base.Channel.CreateOrderAsync(order);
        }
        
        public TooBuzyEntities.Order GetOrderById(int Id) {
            return base.Channel.GetOrderById(Id);
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Order> GetOrderByIdAsync(int Id) {
            return base.Channel.GetOrderByIdAsync(Id);
        }
        
        public TooBuzyEntities.Order[] GetAllOrders() {
            return base.Channel.GetAllOrders();
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Order[]> GetAllOrdersAsync() {
            return base.Channel.GetAllOrdersAsync();
        }
        
        public bool UpdateOrder(TooBuzyEntities.Order order) {
            return base.Channel.UpdateOrder(order);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateOrderAsync(TooBuzyEntities.Order order) {
            return base.Channel.UpdateOrderAsync(order);
        }
        
        public bool DeleteOrder(int Id) {
            return base.Channel.DeleteOrder(Id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteOrderAsync(int Id) {
            return base.Channel.DeleteOrderAsync(Id);
        }
        
        public bool CreateTable(TooBuzyEntities.Table table) {
            return base.Channel.CreateTable(table);
        }
        
        public System.Threading.Tasks.Task<bool> CreateTableAsync(TooBuzyEntities.Table table) {
            return base.Channel.CreateTableAsync(table);
        }
        
        public TooBuzyEntities.Table GetTableById(int Id) {
            return base.Channel.GetTableById(Id);
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Table> GetTableByIdAsync(int Id) {
            return base.Channel.GetTableByIdAsync(Id);
        }
        
        public TooBuzyEntities.Table[] GetAllTables() {
            return base.Channel.GetAllTables();
        }
        
        public System.Threading.Tasks.Task<TooBuzyEntities.Table[]> GetAllTablesAsync() {
            return base.Channel.GetAllTablesAsync();
        }
        
        public bool UpdateTable(TooBuzyEntities.Table table) {
            return base.Channel.UpdateTable(table);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateTableAsync(TooBuzyEntities.Table table) {
            return base.Channel.UpdateTableAsync(table);
        }
        
        public bool DeleteTable(int Id) {
            return base.Channel.DeleteTable(Id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteTableAsync(int Id) {
            return base.Channel.DeleteTableAsync(Id);
        }
    }
}
