using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publish
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

            ////第四步：创建一个队列(queue)
            //channel.QueueDeclare("mytest", true, false, false, null);

            //var msg = Encoding.UTF8.GetBytes("你好"); //因为我们要生成byte数组

            ////以上的四步算是连接rabbitmq，后面的步骤是具体操作
            ////第五步：发布消息   发布消息都用basic前缀
            ////channel.BasicPublish(string.Empty, "mytest", null, msg);
            //channel.BasicPublish(string.Empty, routingKey: "mytest", basicProperties: null, body: msg);


            //Console.Read();//拦住这个进程。
            //               //为啥不释放，释放了ui中就看不到了
            //               //using。。。。
            //               //channel.Dispose();
            //               //connection.Dispose();
            #endregion

            #region 6
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
            ////第三步：申明交换机【因为rabbitmq已经有了自定义的ampq default exchange】 我们当然也可以自定义交换机  也就是显式的指定自定义的交换机，非隐式指定默认的交换机  publish是直接把消息推给交换机的，但交换机有默认的，所以交换机可以不声明
            ////channel.ExchangeDeclare("myexchange", ExchangeType.Direct, true, false, null);//也就是说有个交换机对象，像direct只是个类型而已=>用脑子去想

            ////第四步：创建一个队列(queue)
            //channel.QueueDeclare("mytest", true, false, false, null);

            ////如果是自定义exchange的话，需要把queue绑定到自定义的exchange上，容易出错，但如果是隐式的话，这些工作由rabbitmq默认完成了。
            ////也就是说在erlang的measia数据库中个，有一个路由表，有三个列 exchangename queuename routingkey ，bind就是向这张表插入一条数据，，供以后使用，
            ////channel.QueueBind("mytest", "myexchange", "mytest", null);//routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢

            //for (int i = 0; i < 100; i++)
            //{

            //    var msg = Encoding.UTF8.GetBytes(string.Format("{0}+{1}",i,"你好")); //因为我们要生成byte数组

            //    //以上的四步算是连接rabbitmq，后面的步骤是具体操作  =》有这个认识是，心中有个架构图
            //    //第五步：发布消息   发布消息都用basic前缀=》先推个交换机，后续工作，交换机完成，如把消息推到指定的队列中
            //    //channel.BasicPublish(string.Empty, "mytest", null, msg);
            //    channel.BasicPublish(string.Empty, routingKey: "mytest", basicProperties: null, body: msg);
            //}


            //Console.Read();//拦住这个进程。
            ////为啥不释放，释放了ui中就看不到了
            ////using。。。。
            ////channel.Dispose();
            ////connection.Dispose();
            #endregion


            #region 7
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
            ////第三步：申明交换机【因为rabbitmq已经有了自定义的ampq default exchange】 我们当然也可以自定义交换机  也就是显式的指定自定义的交换机，非隐式指定默认的交换机  publish是直接把消息推给交换机的，但交换机有默认的，所以交换机可以不声明
            //channel.ExchangeDeclare("myexchange", ExchangeType.Direct, true, false, null);//也就是说有个交换机对象，像direct只是个类型而已=>用脑子去想

            ////第四步：创建一个队列(queue)
            //channel.QueueDeclare("log_else", true, false, false, null);
            //channel.QueueDeclare("log_error", true, false, false, null);

            ////如果是自定义exchange的话，需要把queue绑定到自定义的exchange上，容易出错，但如果是隐式的话，这些工作由rabbitmq默认完成了。
            ////也就是说在erlang的measia数据库中个，有一个路由表，有三个列 exchangename queuename routingkey ，bind就是向这张表插入一条数据，，供以后使用，
            ////此需求，必须实现自定义exchange， 默认的无法实现
            ////也说明了，自定义exchange，更灵活，可以实现更强大的功能
            ////此处有个问题：队列 exchange的声明，相互间的binding，应该是在管理端去完成，在publish端完成这个逻辑的绑定是不是不符合常理，也可以定义在消费端=》说明了无论publish consumer不仅仅是做publish和消费的工作，还是管理rabbitmq。=》主方向
            ////当然这些东西，能不在代码中实现，就不要在代码中实现
            ////潜在的一个问题：不要例子这样写，就认为全部都是这样=》找准主方向
            //channel.QueueBind("log_else", "myexchange", "debug", null);//routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢
            //channel.QueueBind("log_else", "myexchange", "info", null);
            //channel.QueueBind("log_else", "myexchange", "warning", null);
            //channel.QueueBind("log_error", "myexchange", "error", null);//consumer定义的话可以忽略这个，但publish呢 =》理解有问题

            //////优化版本
            ////var attr = new string[]{ "debug", "info","warning" };
            ////for (int i = 0; i < attr.Length; i++)
            ////{
            ////    channel.QueueBind("log_error", "myexchange",attr[i], null);/routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢

            ////}
            ////channel.QueueBind("log_error", "myexchange", "error", null);//consumer定义的话可以忽略这个，但publish呢 =》理解有问题

            //for (int i = 0; i < 100; i++)
            //{

            //    var msg = Encoding.UTF8.GetBytes(string.Format("{0}+{1}", i, "你好")); //因为我们要生成byte数组

            //    var level = i % 13 == 0 ? "info" : "error";

            //    //以上的四步算是连接rabbitmq，后面的步骤是具体操作  =》有这个认识是，心中有个架构图
            //    //第五步：发布消息   发布消息都用basic前缀=》先推个交换机，后续工作，交换机完成，如把消息推到指定的队列中
            //    //channel.BasicPublish(string.Empty, "mytest", null, msg);
            //    channel.BasicPublish("myexchange", routingKey: level, basicProperties: null, body: msg);
            //}


            //Console.Read();//拦住这个进程。
            ////为啥不释放，释放了ui中就看不到了
            ////using。。。。
            ////channel.Dispose();
            ////connection.Dispose();
            #endregion

            #region 8
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
            //第三步：申明交换机【因为rabbitmq已经有了自定义的ampq default exchange】 我们当然也可以自定义交换机  也就是显式的指定自定义的交换机，非隐式指定默认的交换机  publish是直接把消息推给交换机的，但交换机有默认的，所以交换机可以不声明
            channel.ExchangeDeclare("myfanoutexchange", ExchangeType.Direct, true, false, null);//也就是说有个交换机对象，像direct只是个类型而已=>用脑子去想

            //第四步：创建一个队列(queue)
            channel.QueueDeclare("myfanoutqueue1", true, false, false, null);
            channel.QueueDeclare("myfanoutqueue2", true, false, false, null);


            //如果是自定义exchange的话，需要把queue绑定到自定义的exchange上，容易出错，但如果是隐式的话，这些工作由rabbitmq默认完成了。
            //也就是说在erlang的measia数据库中个，有一个路由表，有三个列 exchangename queuename routingkey ，bind就是向这张表插入一条数据，，供以后使用，
            //此需求，必须实现自定义exchange， 默认的无法实现
            //也说明了，自定义exchange，更灵活，可以实现更强大的功能
            //此处有个问题：队列 exchange的声明，相互间的binding，应该是在管理端去完成，在publish端完成这个逻辑的绑定是不是不符合常理，也可以定义在消费端=》说明了无论publish consumer不仅仅是做publish和消费的工作，还是管理rabbitmq。=》主方向
            //当然这些东西，能不在代码中实现，就不要在代码中实现
            //潜在的一个问题：不要例子这样写，就认为全部都是这样=》找准主方向
            //channel.QueueBind("log_else", "myexchange", "debug", null);//routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢
            //channel.QueueBind("log_else", "myexchange", "info", null);
            //channel.QueueBind("log_else", "myexchange", "warning", null);
            //channel.QueueBind("log_error", "myexchange", "error", null);//consumer定义的话可以忽略这个，但publish呢 =》理解有问题

            //////优化版本
            ////var attr = new string[]{ "debug", "info","warning" };
            ////for (int i = 0; i < attr.Length; i++)
            ////{
            ////    channel.QueueBind("log_error", "myexchange",attr[i], null);/routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢

            ////}
            ////channel.QueueBind("log_error", "myexchange", "error", null);//consumer定义的话可以忽略这个，但publish呢 =》理解有问题


            //理解为什么定义两个队列，但consumer的话，就单独定义，比较好，消费那个，就定义那个
            channel.QueueBind("myfanoutqueue1", "myfanoutexchange", string.Empty, null);//要理解为什么没有routingkey
            channel.QueueBind("myfanoutqueue2", "myfanoutexchange", string.Empty, null);//要理解为什么没有routingkey


            for (int i = 0; i < 100; i++)
            {

                var msg = Encoding.UTF8.GetBytes(string.Format("{0}+{1}", i, "你好")); //因为我们要生成byte数组

                var level = i % 13 == 0 ? "info" : "error";

                //以上的四步算是连接rabbitmq，后面的步骤是具体操作  =》有这个认识是，心中有个架构图
                //第五步：发布消息   发布消息都用basic前缀=》先推个交换机，后续工作，交换机完成，如把消息推到指定的队列中
                //channel.BasicPublish(string.Empty, "mytest", null, msg);
                channel.BasicPublish("myfanoutexchange", routingKey: string.Empty, basicProperties: null, body: msg);
            }


            Console.Read();//拦住这个进程。
            //为啥不释放，释放了ui中就看不到了
            //using。。。。
            //channel.Dispose();
            //connection.Dispose();
            #endregion

        }
    }
}
