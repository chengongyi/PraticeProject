using System.Collections.Generic;

namespace KafkaExtension.Consumer
{
    public class KafkaConsumerOption
    {
        public string Topic { get; set; }
        public List<string> Servers { get; set; }
        public string GroupId { get; set; }
    }
}