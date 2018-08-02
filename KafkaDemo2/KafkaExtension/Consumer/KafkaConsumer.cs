using System.Collections.Generic;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace KafkaExtension.Consumer
{
    public class KafkaConsumer: Consumer<Null, string>
    {
        private readonly string _topic;

        public KafkaConsumer(IEnumerable<KeyValuePair<string, object>> config, IDeserializer<Null> keyDeserializer, IDeserializer<string> valueDeserializer, string topic) : base(config, keyDeserializer, valueDeserializer)
        {
            _topic = topic;
        } 
    }
}