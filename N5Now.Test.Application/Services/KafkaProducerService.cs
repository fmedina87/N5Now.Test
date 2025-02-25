using Confluent.Kafka;
using Microsoft.Extensions.Options;
using N5Now.Test.Domain.Common.Entities;
using N5Now.Test.Domain.Entities;
using N5Now.Test.Domain.Interfaces.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace N5Now.Test.Application.Services
{
    public class KafkaProducerService: IKafkaProducerService
    {
        private readonly IProducer<Null, string> _producer;
        private readonly AppSettings _appSettings;
        private readonly string _topic;

        public KafkaProducerService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            var kafkaConfig = new ProducerConfig
            {
                BootstrapServers = _appSettings.KafkaConfig?.BoostrapServers,
            };

            _producer = new ProducerBuilder<Null, string>(kafkaConfig).Build();
            _topic = _appSettings.KafkaConfig?.Topic ?? string.Empty;
        }

        public async Task SendMessageAsync<T>(T message)
        {           
            string json = JsonSerializer.Serialize(message);
            await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = json });
        }
    }
}
