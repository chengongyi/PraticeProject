using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Newtonsoft.Json;
using System.Linq;
using KafkaExtension;

namespace Producer
{
     
    public class JobMessage
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //创建参数
            var option = new KafkaProucerOption()
            {
                Topic = "T_1_2",
                Servers = new List<string>() { "172.16.20.60:9092" }
            };

            //工厂模式获取实例
            using (var producer = KafkaProducerFacotry.Create(option))
            {
                while (true)
                {
                    var number = new Random().Next(1, 10000);
                    var jobInfo = new JobMessage() { JobId = number, UserId = number };

                    //执行发送
                    var message = producer.SendAsync(jobInfo).Result;
                    Console.WriteLine($"topic={message.Topic} partition={message.Partition} value={message.Value}");
                }
            }
        } 
      
    }


}
