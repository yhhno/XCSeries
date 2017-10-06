using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace _04.驱动尝试之下载Java的jedis和CSharp的StackExchange.Redis驱动连接redis
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建链接
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("192.168.23.151:6379");

            //获取db
            var database = redis.GetDatabase();

            database.StringSet("username", "jack");

            var str = database.StringGet("username");
        }
    }
}
