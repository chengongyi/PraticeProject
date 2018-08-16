using System.Collections.Generic;

namespace KafkaExtension
{
    public class KafkaProucerOption
    {
        public string Topic { get; set; }
        public List<string> Servers { get; set; }
    }
}