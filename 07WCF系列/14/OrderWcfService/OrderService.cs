using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using BusinessLayer;
using System.ServiceModel;

namespace OrderWcfService
{
    public class OrderService : IOrderService
    {
        /// <summary>
        /// 添加到数据库
        /// </summary>
        /// <param name="order"></param>
        [OperationBehavior(TransactionScopeRequired = true)]
        public void AddOrder(Model.Orders order)
        {
            using (OrderDBDataContext context = new OrderDBDataContext())
            {
                context.Orders.InsertOnSubmit(new BusinessLayer.Orders()
                {
                    OrderID = order.OrderID,
                    OrderName = order.OrderName,
                    CreateTime = order.CreateTime,
                    ProductID = order.ProductID
                });

                context.SubmitChanges();
            }
        }
    }
}
