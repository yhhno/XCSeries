using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Orders
    {
        public int OrderID { get; set; }

        public string OrderName { get; set; }

        public DateTime CreateTime { get; set; }

        public int ProductID { get; set; }
    }
}
