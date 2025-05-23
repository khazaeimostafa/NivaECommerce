using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Messaging.KafkaBase
{
    public class KafkaProducerBase<T> : IKafkaProducer<T>
    {
        public Task ProduceAsync(string topic, T message)
        {
            throw new NotImplementedException();
        }
    }
}
