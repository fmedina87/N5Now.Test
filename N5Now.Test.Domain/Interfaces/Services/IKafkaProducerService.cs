using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Test.Domain.Interfaces.Services
{
    public interface IKafkaProducerService
    {
        Task SendMessageAsync<T>(T message);
    }
}
