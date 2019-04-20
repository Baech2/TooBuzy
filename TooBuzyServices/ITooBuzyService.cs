  using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TooBuzyEntities;

namespace TooBuzyServices
{
    [ServiceContract]
    public interface ITooBuzyService
    {
        [OperationContract]
        void CreateConsumer(Consumer consumer);
        [OperationContract]
        Consumer GetConsumerById(int Id);
        [OperationContract]
        IEnumerable<Consumer> GetAll();
        [OperationContract]
        void UpdateConsumer(Consumer consumer);
        [OperationContract]
        void DeleteConsumer(int Id);
        [OperationContract]
        Consumer GetByInt(int phone);
    }
}
