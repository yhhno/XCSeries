using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 5
            //ConnectionFactory connectionFactory = new ConnectionFactory
            //{
            //    HostName = "127.0.0.1",
            //    UserName = "qqqqqq",
            //    Password = "qqqqqq",
            //    //其他的设置，用默认的，此处不设置，
            //};

            ////第一步：创建connection
            //var connection = connectionFactory.CreateConnection();

            ////第二步：创建一个channel
            //var channel = connection.CreateModel();

            ////第三步：申明交换机【因为rabbitmq已经有了自定义的ampq default exchange】

            ////以上的三步算是连接rabbitmq，后面的步骤是具体操作
            ////第四步：获取消息
            //var result = channel.BasicGet("mytest", true);

            //var msg = Encoding.UTF8.GetString(result.Body);//result中有好多东西，相当于message的存储，
            #endregion

            #region 6
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = "127.0.0.1",
                UserName = "qqqqqq",
                Password = "qqqqqq",
                //其他的设置，用默认的，此处不设置，
            };

            //第一步：创建connection
            var connection = connectionFactory.CreateConnection();

            //第二步：创建一个channel
            var channel = connection.CreateModel();

            //第三步：申明交换机【因为rabbitmq已经有了自定义的ampq default exchange】  我们当然也可以自定义交换机  也就是显式的指定自定义的交换机，非隐式指定默认的交换机   consumer是直接读队列的，所以交换机可以不声明
            //channel.ExchangeDeclare("myexchange", ExchangeType.Direct, true, false, null);//也就是说有个交换机对象，像direct只是个类型而已=>用脑子去想
         


            //以上的四步算是连接rabbitmq，后面的步骤是具体操作=》有这个认识是，心中有个架构图
            //第四步：声明一个队列(queue) 此处的队列如果不声明的话，可能会有个坑，=》consumer是直接读队列的，如果先运行consumer的话，如果没有指定的队列存在会出错的
            channel.QueueDeclare("mytest", true, false, false, null);


            

            //主动获取
            //var result = channel.BasicGet("mytest", true);
            //var msg = Encoding.UTF8.GetString(result.Body);//result中有好多东西，相当于message的存储，

            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            //consumer.Received += Consumer_Received;
            consumer.Received += (sender, e)=>//匿名函数   e相当于restult，但是少了没有指定从哪个队列去获取数据
            {
                //获取msg
                var msg = Encoding.UTF8.GetString(e.Body);

                //只是我们此处的消费是把message输出，当然可以做其他操作。=》用脑子去想
                Console.WriteLine(string.Format("我对message：{0},进行了消费，消费方式其实输出到控制台，当然有其他的方式",msg));
            };

            channel.BasicConsume("mytest", false, consumer);

            Console.Read();//把进程拦住。
            #endregion
        }

        //private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
