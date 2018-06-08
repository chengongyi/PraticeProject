using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Newtonsoft.Json;

namespace Consumer
{
    public class JobMessage
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
    }

    class Program
    {
        private static string TOPIC = "T_1_2";
        public static void Main()
        { 
            var conf = new Dictionary<string, object>
                {
                    { "group.id", $"my-group-002" },
                    //{ "bootstrap.servers", "192.168.240.142:9092" },
                    { "bootstrap.servers", "172.16.20.60:9092" },
                    { "auto.commit.interval.ms", 5000 },
                    { "auto.offset.reset", "earliest" }
                };

       
            Dictionary<int, int> dic = new Dictionary<int, int>();

            using (var consumer = new Consumer<Null, string>(conf, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.OnMessage += (_, msg) =>
                {
                    if (dic.ContainsKey(msg.Partition))
                    {
                        dic[msg.Partition]++;
                    }
                    else
                    {
                        dic.Add(msg.Partition, 1);
                    }

                    Console.WriteLine("======================================");
                    foreach (var item in dic)
                    {
                        Console.WriteLine($"{item.Key}-{item.Value}");
                    }
                };

                consumer.OnError += (_, error)
                    => Console.WriteLine($"Error: {error}");

                consumer.OnConsumeError += (_, msg)
                    => Console.WriteLine($"Consume error ({msg.TopicPartitionOffset}): {msg.Error}");

                consumer.Subscribe(TOPIC);
                 
                while (true)
                {
                    consumer.Poll(TimeSpan.FromMilliseconds(100));
                }
            }
        }
    }
}
