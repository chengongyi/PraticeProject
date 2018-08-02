using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using KafkaExtension;
using KafkaExtension.Consumer;
using Newtonsoft.Json;

namespace Consumer
{

    class Program
    {
        public static void Main()
        {
            var option = new KafkaConsumerOption()
            {
                Topic = "T_1_2",
                Servers = new List<string>() { "172.16.20.60:9092" },
                GroupId = "my-group"
            };

            //工厂模式
            using (var consumer = KafkaConsumerFactory.Create(option, SuccessHandler,null,null))
            {
                while (true)
                {
                    consumer.Poll(TimeSpan.FromMilliseconds(100));
                }
            }
        }

        /// <summary> 成功回调函数 </summary>
        private static void SuccessHandler(object sender, Message<Null, string> msg)
        {
            Console.WriteLine($"Consumer: topic={msg.Topic} partition={msg.Partition} value={msg.Value}");
        }

        private static void ConsumeErrorHandler(object sender, Message msg)
        {
            Console.WriteLine($"Consume error ({msg.TopicPartitionOffset}): {msg.Error}");
        }

        private static void ErrorHandler(object sender, Error error)
        {
            Console.WriteLine($"Error: {error}");
        }

  
    }
}
