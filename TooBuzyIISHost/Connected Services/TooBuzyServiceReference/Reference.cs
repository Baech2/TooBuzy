﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TooBuzyIISHost.TooBuzyServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Consumer", Namespace="http://schemas.datacontract.org/2004/07/TooBuzyEntities")]
    [System.SerializableAttribute()]
    public partial class Consumer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TooBuzyIISHost.TooBuzyServiceReference.Booking[] BookingsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PhoneNoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TooBuzyIISHost.TooBuzyServiceReference.Booking[] Bookings {
            get {
                return this.BookingsField;
            }
            set {
                if ((object.ReferenceEquals(this.BookingsField, value) != true)) {
                    this.BookingsField = value;
                    this.RaisePropertyChanged("Bookings");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PhoneNo {
            get {
                return this.PhoneNoField;
            }
            set {
                if ((this.PhoneNoField.Equals(value) != true)) {
                    this.PhoneNoField = value;
                    this.RaisePropertyChanged("PhoneNo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Booking", Namespace="http://schemas.datacontract.org/2004/07/TooBuzyEntities")]
    [System.SerializableAttribute()]
    public partial class Booking : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TooBuzyIISHost.TooBuzyServiceReference.Consumer ConsumerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ConsumerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TooBuzyIISHost.TooBuzyServiceReference.Table[] TablesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TooBuzyIISHost.TooBuzyServiceReference.Consumer Consumer {
            get {
                return this.ConsumerField;
            }
            set {
                if ((object.ReferenceEquals(this.ConsumerField, value) != true)) {
                    this.ConsumerField = value;
                    this.RaisePropertyChanged("Consumer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ConsumerId {
            get {
                return this.ConsumerIdField;
            }
            set {
                if ((this.ConsumerIdField.Equals(value) != true)) {
                    this.ConsumerIdField = value;
                    this.RaisePropertyChanged("ConsumerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TooBuzyIISHost.TooBuzyServiceReference.Table[] Tables {
            get {
                return this.TablesField;
            }
            set {
                if ((object.ReferenceEquals(this.TablesField, value) != true)) {
                    this.TablesField = value;
                    this.RaisePropertyChanged("Tables");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Table", Namespace="http://schemas.datacontract.org/2004/07/TooBuzyEntities")]
    [System.SerializableAttribute()]
    public partial class Table : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TooBuzyIISHost.TooBuzyServiceReference.Booking BookingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> BookingIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TooBuzyIISHost.TooBuzyServiceReference.Customer CustomerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CustomerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NoOfSeatsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TableNoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TooBuzyIISHost.TooBuzyServiceReference.Booking Booking {
            get {
                return this.BookingField;
            }
            set {
                if ((object.ReferenceEquals(this.BookingField, value) != true)) {
                    this.BookingField = value;
                    this.RaisePropertyChanged("Booking");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> BookingId {
            get {
                return this.BookingIdField;
            }
            set {
                if ((this.BookingIdField.Equals(value) != true)) {
                    this.BookingIdField = value;
                    this.RaisePropertyChanged("BookingId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TooBuzyIISHost.TooBuzyServiceReference.Customer Customer {
            get {
                return this.CustomerField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerField, value) != true)) {
                    this.CustomerField = value;
                    this.RaisePropertyChanged("Customer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CustomerId {
            get {
                return this.CustomerIdField;
            }
            set {
                if ((this.CustomerIdField.Equals(value) != true)) {
                    this.CustomerIdField = value;
                    this.RaisePropertyChanged("CustomerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NoOfSeats {
            get {
                return this.NoOfSeatsField;
            }
            set {
                if ((this.NoOfSeatsField.Equals(value) != true)) {
                    this.NoOfSeatsField = value;
                    this.RaisePropertyChanged("NoOfSeats");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TableNo {
            get {
                return this.TableNoField;
            }
            set {
                if ((this.TableNoField.Equals(value) != true)) {
                    this.TableNoField = value;
                    this.RaisePropertyChanged("TableNo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customer", Namespace="http://schemas.datacontract.org/2004/07/TooBuzyEntities")]
    [System.SerializableAttribute()]
    public partial class Customer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PhoneNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TooBuzyIISHost.TooBuzyServiceReference.Table[] TablesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ZipCodeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PhoneNo {
            get {
                return this.PhoneNoField;
            }
            set {
                if ((this.PhoneNoField.Equals(value) != true)) {
                    this.PhoneNoField = value;
                    this.RaisePropertyChanged("PhoneNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TooBuzyIISHost.TooBuzyServiceReference.Table[] Tables {
            get {
                return this.TablesField;
            }
            set {
                if ((object.ReferenceEquals(this.TablesField, value) != true)) {
                    this.TablesField = value;
                    this.RaisePropertyChanged("Tables");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ZipCode {
            get {
                return this.ZipCodeField;
            }
            set {
                if ((this.ZipCodeField.Equals(value) != true)) {
                    this.ZipCodeField = value;
                    this.RaisePropertyChanged("ZipCode");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TooBuzyServiceReference.ITooBuzyService")]
    public interface ITooBuzyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/CreateConsumerResponse")]
        void CreateConsumer(TooBuzyIISHost.TooBuzyServiceReference.Consumer consumer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/CreateConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/CreateConsumerResponse")]
        System.Threading.Tasks.Task CreateConsumerAsync(TooBuzyIISHost.TooBuzyServiceReference.Consumer consumer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetConsumerById", ReplyAction="http://tempuri.org/ITooBuzyService/GetConsumerByIdResponse")]
        TooBuzyIISHost.TooBuzyServiceReference.Consumer GetConsumerById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetConsumerById", ReplyAction="http://tempuri.org/ITooBuzyService/GetConsumerByIdResponse")]
        System.Threading.Tasks.Task<TooBuzyIISHost.TooBuzyServiceReference.Consumer> GetConsumerByIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAll", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllResponse")]
        TooBuzyIISHost.TooBuzyServiceReference.Consumer[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetAll", ReplyAction="http://tempuri.org/ITooBuzyService/GetAllResponse")]
        System.Threading.Tasks.Task<TooBuzyIISHost.TooBuzyServiceReference.Consumer[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateConsumerResponse")]
        void UpdateConsumer(TooBuzyIISHost.TooBuzyServiceReference.Consumer consumer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/UpdateConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/UpdateConsumerResponse")]
        System.Threading.Tasks.Task UpdateConsumerAsync(TooBuzyIISHost.TooBuzyServiceReference.Consumer consumer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteConsumerResponse")]
        void DeleteConsumer(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/DeleteConsumer", ReplyAction="http://tempuri.org/ITooBuzyService/DeleteConsumerResponse")]
        System.Threading.Tasks.Task DeleteConsumerAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetByInt", ReplyAction="http://tempuri.org/ITooBuzyService/GetByIntResponse")]
        TooBuzyIISHost.TooBuzyServiceReference.Consumer GetByInt(int phone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITooBuzyService/GetByInt", ReplyAction="http://tempuri.org/ITooBuzyService/GetByIntResponse")]
        System.Threading.Tasks.Task<TooBuzyIISHost.TooBuzyServiceReference.Consumer> GetByIntAsync(int phone);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITooBuzyServiceChannel : TooBuzyIISHost.TooBuzyServiceReference.ITooBuzyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TooBuzyServiceClient : System.ServiceModel.ClientBase<TooBuzyIISHost.TooBuzyServiceReference.ITooBuzyService>, TooBuzyIISHost.TooBuzyServiceReference.ITooBuzyService {
        
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
        
        public void CreateConsumer(TooBuzyIISHost.TooBuzyServiceReference.Consumer consumer) {
            base.Channel.CreateConsumer(consumer);
        }
        
        public System.Threading.Tasks.Task CreateConsumerAsync(TooBuzyIISHost.TooBuzyServiceReference.Consumer consumer) {
            return base.Channel.CreateConsumerAsync(consumer);
        }
        
        public TooBuzyIISHost.TooBuzyServiceReference.Consumer GetConsumerById(int Id) {
            return base.Channel.GetConsumerById(Id);
        }
        
        public System.Threading.Tasks.Task<TooBuzyIISHost.TooBuzyServiceReference.Consumer> GetConsumerByIdAsync(int Id) {
            return base.Channel.GetConsumerByIdAsync(Id);
        }
        
        public TooBuzyIISHost.TooBuzyServiceReference.Consumer[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<TooBuzyIISHost.TooBuzyServiceReference.Consumer[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void UpdateConsumer(TooBuzyIISHost.TooBuzyServiceReference.Consumer consumer) {
            base.Channel.UpdateConsumer(consumer);
        }
        
        public System.Threading.Tasks.Task UpdateConsumerAsync(TooBuzyIISHost.TooBuzyServiceReference.Consumer consumer) {
            return base.Channel.UpdateConsumerAsync(consumer);
        }
        
        public void DeleteConsumer(int Id) {
            base.Channel.DeleteConsumer(Id);
        }
        
        public System.Threading.Tasks.Task DeleteConsumerAsync(int Id) {
            return base.Channel.DeleteConsumerAsync(Id);
        }
        
        public TooBuzyIISHost.TooBuzyServiceReference.Consumer GetByInt(int phone) {
            return base.Channel.GetByInt(phone);
        }
        
        public System.Threading.Tasks.Task<TooBuzyIISHost.TooBuzyServiceReference.Consumer> GetByIntAsync(int phone) {
            return base.Channel.GetByIntAsync(phone);
        }
    }
}
