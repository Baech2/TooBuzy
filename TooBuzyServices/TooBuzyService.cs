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
        private ConsumerController ConsCtr = new ConsumerController();

        [OperationBehavior(TransactionScopeRequired =true)]
        public void CreateConsumer(Consumer consumer)
        {
            ConsCtr.Create(consumer);
        }
        [OperationBehavior]
        public void DeleteConsumer(int Id)
        {
            ConsCtr.Delete(Id);
        }
        [OperationBehavior]
        public IEnumerable<Consumer> GetAll()
        {
            var principal = Thread.CurrentPrincipal;
            IEnumerable<Consumer> foundConsumers = ConsCtr.GetAll();
            return foundConsumers;
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
        public void UpdateConsumer(Consumer consumer)
        {
            ConsCtr.Update(consumer);
        }


    }
}
