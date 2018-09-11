using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OrderWcfService
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IOrderService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void AddOrder(Model.Orders order);
    }
}
