using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class MyParameterInspector : IParameterInspector
    {
        private int maxLength = 0;

        public MyParameterInspector(int maxLength)
        {
            this.maxLength = maxLength;
        }
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {

        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            //operationName：方法名
            if (operationName == "DoWork")
            {
                //inputs: 就是方法中的参数
                var username = Convert.ToString(inputs[0]);

                if (string.IsNullOrEmpty(username))
                {
                    throw new Exception("当前的username不可为空。。。。");
                }

                if (username.Length > maxLength)
                {
                    throw new Exception(string.Format("当前的username不可大于{0}。。。。", maxLength));
                }
            }

            return null;
        }
    }
}
