using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
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

            ////第三步：申明交换机【因为rabbitmq已经有了自定义的ampq default exchange】  我们当然也可以自定义交换机  也就是显式的指定自定义的交换机，非隐式指定默认的交换机   consumer是直接读队列的，所以交换机可以不声明
            ////channel.ExchangeDeclare("myexchange", ExchangeType.Direct, true, false, null);//也就是说有个交换机对象，像direct只是个类型而已=>用脑子去想



            ////以上的四步算是连接rabbitmq，后面的步骤是具体操作=》有这个认识是，心中有个架构图
            ////第四步：声明一个队列(queue) 此处的队列如果不声明的话，可能会有个坑，=》consumer是直接读队列的，如果先运行consumer的话，如果没有指定的队列存在会出错的
            //channel.QueueDeclare("mytest", true, false, false, null);




            ////主动获取
            ////var result = channel.BasicGet("mytest", true);
            ////var msg = Encoding.UTF8.GetString(result.Body);//result中有好多东西，相当于message的存储，

            //EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            ////consumer.Received += Consumer_Received;
            //consumer.Received += (sender, e)=>//匿名函数   e相当于restult，但是少了没有指定从哪个队列去获取数据
            //{
            //    //获取msg
            //    var msg = Encoding.UTF8.GetString(e.Body);

            //    //只是我们此处的消费是把message输出，当然可以做其他操作。=》用脑子去想
            //    Console.WriteLine(string.Format("我对message：{0},进行了消费，消费方式其实输出到控制台，当然有其他的方式",msg));
            //};

            //channel.BasicConsume("mytest", false, consumer);

            //Console.Read();//把进程拦住。
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

            ////第三步：申明交换机【因为rabbitmq已经有了自定义的ampq default exchange】  我们当然也可以自定义交换机  也就是显式的指定自定义的交换机，非隐式指定默认的交换机   consumer是直接读队列的，所以交换机可以不声明
            //channel.ExchangeDeclare("myexchange", ExchangeType.Direct, true, false, null);//也就是说有个交换机对象，像direct只是个类型而已=>用脑子去想



            ////以上的四步算是连接rabbitmq，后面的步骤是具体操作=》有这个认识是，心中有个架构图
            ////第四步：声明一个队列(queue) 此处的队列如果不声明的话，可能会有个坑，=》consumer是直接读队列的，如果先运行consumer的话，如果没有指定的队列存在会出错的
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
            //channel.QueueBind("log_error", "myexchange", "error", null);//一个consumer只消费一个queue，所以不关error=》当时我还想着如何在一个地方处理不同的情况呢？=》分析不清楚，=》逻辑过程没走，经验主义=>之前想的是一个consumer只处理一个queue，但此时只是定义，不是处理queue呀，所以说可以全部定义的，当然也可以在两个处理queue中分别去定义，绑定

            //////优化版本
            ////var attr = new string[]{ "debug", "info","warning" };
            ////for (int i = 0; i < attr.Length; i++)
            ////{
            ////    channel.QueueBind("log_error", "myexchange",attr[i], null);/routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢

            ////}
            ////channel.QueueBind("log_error", "myexchange", "error", null);//一个consumer只消费一个queue，所以不关error=》理解有问题


            ////主动获取
            ////var result = channel.BasicGet("mytest", true);
            ////var msg = Encoding.UTF8.GetString(result.Body);//result中有好多东西，相当于message的存储，

            //EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            ////consumer.Received += Consumer_Received;
            //consumer.Received += (sender, e) =>//匿名函数   e相当于restult，但是少了没有指定从哪个队列去获取数据
            //{
            //    //获取msg
            //    var msg = Encoding.UTF8.GetString(e.Body);

            //    //只是我们此处的消费是把message输出，当然可以做其他操作。=》用脑子去想
            //    Console.WriteLine(string.Format("我对message：{0},进行了消费，消费方式其实输出到控制台，当然有其他的方式", msg));
            //};

            //channel.BasicConsume("log_else", false, consumer);

            //Console.Read();//把进程拦住。
            #endregion

            #region 8
            // ConnectionFactory connectionFactory = new ConnectionFactory
            // {
            //     HostName = "127.0.0.1",
            //     UserName = "qqqqqq",
            //     Password = "qqqqqq",
            //     //其他的设置，用默认的，此处不设置，
            // };

            // //第一步：创建connection
            // var connection = connectionFactory.CreateConnection();

            // //第二步：创建一个channel
            // var channel = connection.CreateModel();

            // //第三步：申明交换机【因为rabbitmq已经有了自定义的ampq default exchange】  我们当然也可以自定义交换机  也就是显式的指定自定义的交换机，非隐式指定默认的交换机   consumer是直接读队列的，所以交换机可以不声明
            // channel.ExchangeDeclare("myfanoutexchange", ExchangeType.Direct, true, false, null);//也就是说有个交换机对象，像direct只是个类型而已=>用脑子去想



            // //以上的四步算是连接rabbitmq，后面的步骤是具体操作=》有这个认识是，心中有个架构图
            // //第四步：声明一个队列(queue) 此处的队列如果不声明的话，可能会有个坑，=》consumer是直接读队列的，如果先运行consumer的话，如果没有指定的队列存在会出错的
            // channel.QueueDeclare("myfanoutqueue1", true, false, false, null);
            // channel.QueueDeclare("myfanoutqueue2", true, false, false, null);


            // //如果是自定义exchange的话，需要把queue绑定到自定义的exchange上，容易出错，但如果是隐式的话，这些工作由rabbitmq默认完成了。
            // //也就是说在erlang的measia数据库中个，有一个路由表，有三个列 exchangename queuename routingkey ，bind就是向这张表插入一条数据，，供以后使用，
            // //此需求，必须实现自定义exchange， 默认的无法实现
            // //也说明了，自定义exchange，更灵活，可以实现更强大的功能
            // //此处有个问题：队列 exchange的声明，相互间的binding，应该是在管理端去完成，在publish端完成这个逻辑的绑定是不是不符合常理，也可以定义在消费端=》说明了无论publish consumer不仅仅是做publish和消费的工作，还是管理rabbitmq。=》主方向
            // //当然这些东西，能不在代码中实现，就不要在代码中实现
            // //潜在的一个问题：不要例子这样写，就认为全部都是这样=》找准主方向
            // //channel.QueueBind("log_else", "myexchange", "debug", null);//routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢
            // //channel.QueueBind("log_else", "myexchange", "info", null);
            // //channel.QueueBind("log_else", "myexchange", "warning", null);
            // //channel.QueueBind("log_error", "myexchange", "error", null);//一个consumer只消费一个queue，所以不关error=》当时我还想着如何在一个地方处理不同的情况呢？=》分析不清楚，=》逻辑过程没走，经验主义=>之前想的是一个consumer只处理一个queue，但此时只是定义，不是处理queue呀，所以说可以全部定义的，当然也可以在两个处理queue中分别去定义，绑定

            // //////优化版本
            // ////var attr = new string[]{ "debug", "info","warning" };
            // ////for (int i = 0; i < attr.Length; i++)
            // ////{
            // ////    channel.QueueBind("log_error", "myexchange",attr[i], null);/routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢

            // ////}
            // ////channel.QueueBind("log_error", "myexchange", "error", null);//一个consumer只消费一个queue，所以不关error=》理解有问题

            // //理解为什么定义两个队列，但consumer的话，就单独定义，比较好，消费那个，就定义那个，如此处consumer1消费myfanoutqueue1，就只定义myfanoutqueue1.
            // channel.QueueBind("myfanoutqueue1", "myfanoutexchange", string.Empty, null);//要理解为什么没有routingkey
            // channel.QueueBind("myfanoutqueue2", "myfanoutexchange", string.Empty, null);//要理解为什么没有routingkey


            // //主动获取
            // //var result = channel.BasicGet("mytest", true);
            // //var msg = Encoding.UTF8.GetString(result.Body);//result中有好多东西，相当于message的存储，

            // EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            // //consumer.Received += Consumer_Received;
            // consumer.Received += (sender, e) =>//匿名函数   e相当于restult，但是少了没有指定从哪个队列去获取数据
            // {
            //     //获取msg
            //     var msg = Encoding.UTF8.GetString(e.Body);

            //     //只是我们此处的消费是把message输出，当然可以做其他操作。=》用脑子去想
            //     Console.WriteLine(string.Format("我对message：{0},进行了消费，消费方式其实输出到控制台，当然有其他的方式", msg));
            // };

            // //定义了两个队列，单个consumer消费其中的一个队列，此时就不可以点击两次exe，充当两个consumer了。=>拒绝不加思考的就点击两次exe
            // channel.BasicConsume("myfanoutqueue1", false, consumer);


            // Console.WriteLine("consumer端启动完成！！！");
            //Console.Read();//把进程拦住。
            #endregion

            #region 9
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

            ////第三步：申明交换机【因为rabbitmq已经有了自定义的ampq default exchange】  我们当然也可以自定义交换机  也就是显式的指定自定义的交换机，非隐式指定默认的交换机   consumer是直接读队列的，所以交换机可以不声明
            //channel.ExchangeDeclare("myHeadersexchange", ExchangeType.Headers, true, false, null);//也就是说有个交换机对象，像direct只是个类型而已=>用脑子去想



            ////以上的四步算是连接rabbitmq，后面的步骤是具体操作=》有这个认识是，心中有个架构图
            ////第四步：声明一个队列(queue) 此处的队列如果不声明的话，可能会有个坑，=》consumer是直接读队列的，如果先运行consumer的话，如果没有指定的队列存在会出错的
            //channel.QueueDeclare("myHeaderqueue1", true, false, false, null);
            //channel.QueueDeclare("myHeaderqueue2", true, false, false, null);


            ////如果是自定义exchange的话，需要把queue绑定到自定义的exchange上，容易出错，但如果是隐式的话，这些工作由rabbitmq默认完成了。
            ////也就是说在erlang的measia数据库中个，有一个路由表，有三个列 exchangename queuename routingkey ，bind就是向这张表插入一条数据，，供以后使用，
            ////此需求，必须实现自定义exchange， 默认的无法实现
            ////也说明了，自定义exchange，更灵活，可以实现更强大的功能
            ////此处有个问题：队列 exchange的声明，相互间的binding，应该是在管理端去完成，在publish端完成这个逻辑的绑定是不是不符合常理，也可以定义在消费端=》说明了无论publish consumer不仅仅是做publish和消费的工作，还是管理rabbitmq。=》主方向
            ////当然这些东西，能不在代码中实现，就不要在代码中实现
            ////潜在的一个问题：不要例子这样写，就认为全部都是这样=》找准主方向
            ////channel.QueueBind("log_else", "myexchange", "debug", null);//routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢
            ////channel.QueueBind("log_else", "myexchange", "info", null);
            ////channel.QueueBind("log_else", "myexchange", "warning", null);
            ////channel.QueueBind("log_error", "myexchange", "error", null);//一个consumer只消费一个queue，所以不关error=》当时我还想着如何在一个地方处理不同的情况呢？=》分析不清楚，=》逻辑过程没走，经验主义=>之前想的是一个consumer只处理一个queue，但此时只是定义，不是处理queue呀，所以说可以全部定义的，当然也可以在两个处理queue中分别去定义，绑定

            ////////优化版本
            //////var attr = new string[]{ "debug", "info","warning" };
            //////for (int i = 0; i < attr.Length; i++)
            //////{
            //////    channel.QueueBind("log_error", "myexchange",attr[i], null);/routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢

            //////}
            //////channel.QueueBind("log_error", "myexchange", "error", null);//一个consumer只消费一个queue，所以不关error=》理解有问题

            ////理解为什么定义两个队列，但consumer的话，就单独定义，比较好，消费那个，就定义那个，如此处consumer1消费myfanoutqueue1，就只定义myfanoutqueue1.
            //channel.QueueBind("myHeaderqueue1", "myHeadersexchange", string.Empty, new Dictionary<string, object>
            //{
            //    { "x-match","any"},
            //    { "username","jack"},
            //    { "password","123456"}
            //});//要理解为什么没有routingkey,但是我原本想是这样的，先在一个地方写多个值，然后在一个地方设置x-match=》错了，没有认真去看文档=》这个完全可以加个逻辑判断就可以了，先判断x-match的值，然后决定接下来的逻辑处理，=》文档看的不仔细呀，想想当时看到了，可以理解不，=》这个需要文档+哪个绑定时的参数类型共同去看才可以的。=》有可能看了，也不知道如何先手，不能气馁，更不能停止
            //channel.QueueBind("myHeaderqueue2", "myHeadersexchange", string.Empty, new Dictionary<string, object>
            //{
            //    { "x-match","all"},
            //    { "username","jack"},
            //    { "password","123456"}
            //});//要理解为什么没有routingkey,但是我原本想是这样的，先在一个地方写多个值，然后在一个地方设置x-match=》错了，没有认真去看文档=》这个完全可以加个逻辑判断就可以了，先判断x-match的值，然后决定接下来的逻辑处理，=》文档看的不仔细呀，想想当时看到了，可以理解不，=》这个需要文档+哪个绑定时的参数类型共同去看才可以的。=》有可能看了，也不知道如何先手，不能气馁，更不能停止


            ////主动获取
            ////var result = channel.BasicGet("mytest", true);
            ////var msg = Encoding.UTF8.GetString(result.Body);//result中有好多东西，相当于message的存储，

            //EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            ////consumer.Received += Consumer_Received;
            //consumer.Received += (sender, e) =>//匿名函数   e相当于restult，但是少了没有指定从哪个队列去获取数据
            //{
            //    //获取msg
            //    var msg = Encoding.UTF8.GetString(e.Body);

            //    //只是我们此处的消费是把message输出，当然可以做其他操作。=》用脑子去想
            //    Console.WriteLine(string.Format("我对message：{0},进行了消费，消费方式其实输出到控制台，当然有其他的方式", msg));
            //};

            ////定义了两个队列，单个consumer消费其中的一个队列，此时就不可以点击两次exe，充当两个consumer了。=>拒绝不加思考的就点击两次exe
            //channel.BasicConsume("myHeaderqueue1", false, consumer);


            //Console.WriteLine("consumer端启动完成！！！");
            //Console.Read();//把进程拦住。
            #endregion

            #region 10
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

            ////第三步：申明交换机【因为rabbitmq已经有了自定义的ampq default exchange】  我们当然也可以自定义交换机  也就是显式的指定自定义的交换机，非隐式指定默认的交换机   consumer是直接读队列的，所以交换机可以不声明
            //channel.ExchangeDeclare("mytopicexchange", ExchangeType.Topic, true, false, null);//也就是说有个交换机对象，像direct只是个类型而已=>用脑子去想



            ////以上的四步算是连接rabbitmq，后面的步骤是具体操作=》有这个认识是，心中有个架构图
            ////第四步：声明一个队列(queue) 此处的队列如果不声明的话，可能会有个坑，=》consumer是直接读队列的，如果先运行consumer的话，如果没有指定的队列存在会出错的
            //channel.QueueDeclare("mytopicqueue1", true, false, false, null);
            //channel.QueueDeclare("mytopicqueue2", true, false, false, null);


            ////如果是自定义exchange的话，需要把queue绑定到自定义的exchange上，容易出错，但如果是隐式的话，这些工作由rabbitmq默认完成了。
            ////也就是说在erlang的measia数据库中个，有一个路由表，有三个列 exchangename queuename routingkey ，bind就是向这张表插入一条数据，，供以后使用，
            ////此需求，必须实现自定义exchange， 默认的无法实现
            ////也说明了，自定义exchange，更灵活，可以实现更强大的功能
            ////此处有个问题：队列 exchange的声明，相互间的binding，应该是在管理端去完成，在publish端完成这个逻辑的绑定是不是不符合常理，也可以定义在消费端=》说明了无论publish consumer不仅仅是做publish和消费的工作，还是管理rabbitmq。=》主方向
            ////当然这些东西，能不在代码中实现，就不要在代码中实现
            ////潜在的一个问题：不要例子这样写，就认为全部都是这样=》找准主方向
            ////channel.QueueBind("log_else", "myexchange", "debug", null);//routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢
            ////channel.QueueBind("log_else", "myexchange", "info", null);
            ////channel.QueueBind("log_else", "myexchange", "warning", null);
            ////channel.QueueBind("log_error", "myexchange", "error", null);//一个consumer只消费一个queue，所以不关error=》当时我还想着如何在一个地方处理不同的情况呢？=》分析不清楚，=》逻辑过程没走，经验主义=>之前想的是一个consumer只处理一个queue，但此时只是定义，不是处理queue呀，所以说可以全部定义的，当然也可以在两个处理queue中分别去定义，绑定

            ////////优化版本
            //////var attr = new string[]{ "debug", "info","warning" };
            //////for (int i = 0; i < attr.Length; i++)
            //////{
            //////    channel.QueueBind("log_error", "myexchange",attr[i], null);/routingkey默认是队列名，那也可以自己定义=》可以自定义的这个特性，可以实现是什么功能呢

            //////}
            //////channel.QueueBind("log_error", "myexchange", "error", null);//一个consumer只消费一个queue，所以不关error=》理解有问题

            ////理解为什么定义两个队列，但consumer的话，就单独定义，比较好，消费那个，就定义那个，如此处consumer1消费myfanoutqueue1，就只定义myfanoutqueue1.
            //channel.QueueBind("mytopicqueue1", "mytopicexchange", "*.com", null);
            //channel.QueueBind("mytopicqueue2", "mytopicexchange", "*.cn", null);
           


            ////主动获取
            ////var result = channel.BasicGet("mytest", true);
            ////var msg = Encoding.UTF8.GetString(result.Body);//result中有好多东西，相当于message的存储，

            //EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            ////consumer.Received += Consumer_Received;
            //consumer.Received += (sender, e) =>//匿名函数   e相当于restult，但是少了没有指定从哪个队列去获取数据
            //{
            //    //获取msg
            //    var msg = Encoding.UTF8.GetString(e.Body);

            //    //只是我们此处的消费是把message输出，当然可以做其他操作。=》用脑子去想
            //    Console.WriteLine(string.Format("我对message：{0},进行了消费，消费方式其实输出到控制台，当然有其他的方式", msg));
            //};

            ////定义了两个队列，单个consumer消费其中的一个队列，此时就不可以点击两次exe，充当两个consumer了。=>拒绝不加思考的就点击两次exe
            //channel.BasicConsume("mytopicqueue1", false, consumer);


            //Console.WriteLine("consumer端启动完成！！！");
            //Console.Read();//把进程拦住。
            #endregion


            #region 11  server端
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

            channel.QueueDeclare("rpc_queue", true, false, false, null);

            Subscription subscription = new Subscription(channel, "rpc_queue");
            MySimpleRpcServer server = new MySimpleRpcServer(subscription);
            Console.WriteLine("server端启动完成！！！");
            server.MainLoop();


            Console.Read();//把进程拦住。
            #endregion
        }

        //private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }

   public class MySimpleRpcServer : SimpleRpcServer
    {
        public MySimpleRpcServer(Subscription subscription) : base(subscription)
        {

        }
        public override byte[] HandleCall(bool isRedelivered, IBasicProperties requestProperties, byte[] body, out IBasicProperties replyProperties)
        {
            return base.HandleCall(isRedelivered, requestProperties, body, out replyProperties);
        }
        public override byte[] HandleSimpleCall(bool isRedelivered, IBasicProperties requestProperties, byte[] body, out IBasicProperties replyProperties)
        {
            //return base.HandleSimpleCall(isRedelivered, requestProperties, body, out replyProperties);

            replyProperties = null;
            var msg = string.Format("d当前文字长度是：{0}", Encoding.UTF8.GetString(body).Length);
            return Encoding.UTF8.GetBytes(msg);
        }
        public override void ProcessRequest(BasicDeliverEventArgs evt)
        {
            base.ProcessRequest(evt);
        }
    }
}
