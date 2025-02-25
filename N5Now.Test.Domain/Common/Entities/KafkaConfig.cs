using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Test.Domain.Common.Entities
{
    public class KafkaConfig
    {
        public string? Topic { get; set; }
        public string? BoostrapServers { get; set; }
        public string? GroupId { get; set; }
        public string? PartitionNumber { get; set; }

    }
}
