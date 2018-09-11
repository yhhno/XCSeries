using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using BusinessLayer;
using System.ServiceModel;

namespace ProductWcfService
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// 添加到数据库
        /// </summary>
        /// <param name="order"></param>
        [OperationBehavior(TransactionScopeRequired = true)]
        /// <summary>
        /// 添加到数据库
        /// </summary>
        /// <param name="order"></param>
        public void DecreaseNum(int productID)
        {
            using (ProductDBDataContext context = new ProductDBDataContext())
            {
                var product = context.Product.FirstOrDefault(i => i.ProductID == productID);

                if (product != null)
                {
                    product.ProductNums--;
                    context.SubmitChanges();
                }
            }
        }
    }
}
