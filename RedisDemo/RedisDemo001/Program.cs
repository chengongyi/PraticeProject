using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisDemo001
{
    class Program
    { 
        private static ConfigurationOptions configurationOptions = ConfigurationOptions.Parse("127.0.0.1" + ":" + "6379");
        private static readonly object Locker = new object();
        private static ConnectionMultiplexer redisConn;

        /// <summary>
        /// 单例获取
        /// </summary>
        public static ConnectionMultiplexer RedisConn
        {
            get
            {
                if (redisConn == null)
                {
                    lock (Locker)
                    {
                        if (redisConn == null || !redisConn.IsConnected)
                        {
                            redisConn = ConnectionMultiplexer.Connect(configurationOptions);
                        }
                    }
                }
                return redisConn;
            }
        }

        static void Main(string[] args)
        {
            var db = RedisConn.GetDatabase();

         
            db.HashSet("student", new[]
            {
                new HashEntry("name","rex"),
                new HashEntry("age",18)
            });
            Console.WriteLine(db.HashGet("student", "name"));

            var infos = db.HashGetAll("student");
            foreach (var entry in infos)
            {
                Console.WriteLine("{0}-{1}",entry.Name,entry.Value);   
            }
        }

        /// <summary>
        /// 发布订阅
        /// </summary>
        private static void Pub_Sub()
        {
            ISubscriber sub = RedisConn.GetSubscriber();

            Task.Run(() => { sub.Subscribe("messages", (channel, message) => { Console.WriteLine((string) message); }); });


            Task.Run(() =>
            {
                Console.WriteLine("倒计时5秒");
                Thread.Sleep(5000);
                Console.WriteLine("发消息：{0}", Thread.CurrentThread.Name);
                sub.Publish("messages", "hello");
            });

            Console.Read();
        }


        /// <summary>
        /// 最简单的例子
        /// </summary>
        private static void SimpleDemo()
        {
            var conn = ConnectionMultiplexer.Connect("127.0.0.1" + ":" + "6379");

            var db = conn.GetDatabase();

            Console.WriteLine(db.StringGet("test1"));

            db.StringSet("school", "上海学校");
            Console.WriteLine(db.StringGet("school"));
        }
    }
}
