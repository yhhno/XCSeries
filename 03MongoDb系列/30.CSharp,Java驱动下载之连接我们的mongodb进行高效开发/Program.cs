using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30.CSharp_Java驱动下载之连接我们的mongodb进行高效开发
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var mydb = client.GetDatabase("ctrip");
            var mycollection = mydb.GetCollection<Test>("plane");
            //
            mycollection.InsertOne(new Test()
            {
                Name = "jack"
            });
            ExpressionFilterDefinition<Test> expression = new ExpressionFilterDefinition<Test>(i => i.Name == "jack");
            var items = mycollection.Find<Test>(expression).ToList();
        }
    }

    public class  Test
    {
        public string Name { get; set; }
    }
}
