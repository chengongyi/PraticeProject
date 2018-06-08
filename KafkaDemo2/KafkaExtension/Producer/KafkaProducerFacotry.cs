using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Confluent.Kafka.Serialization;

namespace KafkaExtension
{
    public class KafkaProducerFacotry
    {
        private static readonly Dictionary<string, object> Config = new Dictionary<string, object>();

        private static KafkaProucer _instance;

        private static readonly object LockObj = new object();

        public static KafkaProucer Create(KafkaProucerOption opt)
        {
            if (opt == null)
                throw new ArgumentException("必须提供参数");

            if (string.IsNullOrEmpty(opt.Topic))
                throw new ArgumentException("必须提供主题");

            if (opt.Servers == null || !opt.Servers.Any())
                throw new ArgumentException("必须提供主机名：端口号");

            if (_instance == null)
            {
                lock (LockObj)
                {
                    if (_instance == null)
                    {
                        Config.Add("bootstrap.servers", string.Join(",", opt.Servers));
                        var producer = new KafkaProucer(Config, null, new StringSerializer(Encoding.UTF8), opt.Topic);
                        return producer;
                    }
                }
            }
            return _instance;
        }
    }
}