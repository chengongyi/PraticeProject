using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Newtonsoft.Json;

namespace Producer
{
    public class Program
    {
        private static string TOPIC = "T_1_2";
        public static void Main(string[] args)
        {
            var config = new Dictionary<string, object>
            {
                //{ "bootstrap.servers", "192.168.240.142:9092" },
             { "bootstrap.servers", "172.16.20.60:9092" }
            };

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                while (true)
                {
                    DoJob(producer);
                    Thread.Sleep(1000);
                }
               
            }
        }

        public static async Task DoJob(Producer<Null, string> producer)
        {
            var number = new Random().Next(1, 100000);

            var jobInfo = new JobMessage() { JobId = number, UserId = number };

            var json = JsonConvert.SerializeObject(jobInfo);

            var dr = await producer.ProduceAsync(TOPIC, null, json);

            Console.WriteLine($"Produce Topic:{dr.Topic} Partition:{dr.Partition}");
        }
    }

    public class JobMessage
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
    }
}
