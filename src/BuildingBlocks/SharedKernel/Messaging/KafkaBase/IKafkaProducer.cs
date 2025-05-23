using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Messaging.KafkaBase;

public interface IKafkaProducer<T>
{
    Task ProduceAsync(string topic, T message);
}

