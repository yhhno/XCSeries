using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductWcfService
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IProductService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DecreaseNum(int productID);
    }
}
