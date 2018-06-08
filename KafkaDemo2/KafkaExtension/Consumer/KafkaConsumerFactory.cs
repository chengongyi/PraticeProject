using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace KafkaExtension.Consumer
{
    public class KafkaConsumerFactory
    {
        private static readonly Dictionary<string, object> Config = new Dictionary<string, object>()
        {
            { "auto.commit.interval.ms", 5000 },
            { "auto.offset.reset", "earliest" },
        };

        private static KafkaConsumer _instance;

        private static readonly object LockObj = new object();

        private static Action<object, Message<Null, string>> _successCallback;
        private static Action<object, Error> _erroCallback;
        private static Action<object, Message> _consumeErrorCallback;

        public static KafkaConsumer Create(KafkaConsumerOption opt, Action<object, Message<Null, string>> successCallback, Action<object, Error> erroCallback = null, Action<object, Message> consumeErrorCallback = null)
        {
            if (opt == null)
                throw new ArgumentException("必须提供参数");

            if (string.IsNullOrEmpty(opt.Topic))
                throw new ArgumentException("必须提供主题");

            if (opt.Servers == null || !opt.Servers.Any())
                throw new ArgumentException("必须提供主机名：端口号");

            if (string.IsNullOrEmpty(opt.GroupId))
                throw new ArgumentException("必须提供组名");

            if (successCallback == null)
                throw new ArgumentException("必须提供成功的回调");

            if (_instance == null)
            {
                lock (LockObj)
                {
                    if (_instance == null)
                    {
                        Config.Add("bootstrap.servers", string.Join(",", opt.Servers));
                        Config.Add("group.id", opt.GroupId);
                        var consumer = new KafkaConsumer(Config, null, new StringDeserializer(Encoding.UTF8), opt.Topic);
                        consumer.Subscribe(opt.Topic);

                        _successCallback = successCallback;
                        _erroCallback = erroCallback;
                        _consumeErrorCallback = consumeErrorCallback;

                        consumer.OnMessage += On_Message;
                        consumer.OnError += On_Error;
                        consumer.OnConsumeError += On_ConsumeError;
                        return consumer;
                    }
                }
            }
            return _instance;
        }

        private static void On_ConsumeError(object sender, Message e)
        {
            _consumeErrorCallback?.Invoke(sender, e);
        }

        private static void On_Error(object sender, Error e)
        {
            _erroCallback?.Invoke(sender, e);
        }

        private static void On_Message(object sender, Message<Null, string> e)
        {
            _successCallback?.Invoke(sender, e);
        }
    }
}
