using System.Collections.Generic;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Newtonsoft.Json;

namespace KafkaExtension
{
    public class KafkaProucer : Producer<Null, string>
    {
        private readonly string _topic;
        public KafkaProucer(IEnumerable<KeyValuePair<string, object>> config, ISerializer<Null> keySerializer, ISerializer<string> valueSerializer, string topic) : base(config, keySerializer, valueSerializer)
        {
            _topic = topic;
        }

        public async Task<Message<Null, string>> SendAsync(object msg)
        {
            var jsonMsg = JsonConvert.SerializeObject(msg);
            return await base.ProduceAsync(_topic, null, jsonMsg);
        }
    }
}