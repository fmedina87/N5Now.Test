using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Test.Domain.Common.Entities
{
    public class AppSettings
    {
        public ConnectionStrings? ConnectionStrings { get; set; }
        public KafkaConfig? KafkaConfig { get; set; }
        public Elasticsearch? Elasticsearch { get; set; }
    }
}
