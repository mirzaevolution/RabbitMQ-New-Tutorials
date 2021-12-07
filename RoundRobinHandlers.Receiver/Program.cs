using System;
using System.Threading;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RoundRobinHandlers.Receiver
{
    class Program
    {
        static void Start(int millisecond)
        {
            IConnection connection = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672
            }.CreateConnection();
            string queueName = "round-robin-queue";
            IModel channel =  connection.CreateModel();
            Console.WriteLine($"Worker: {Guid.NewGuid()}");
            channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: true);
            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            EventingBasicConsumer eventingBasicConsumer = new EventingBasicConsumer(channel);
            eventingBasicConsumer.Received += (s, e) =>
            {
                string message = Encoding.UTF8.GetString(e.Body.ToArray());
                Console.WriteLine($"\n(Utc@{DateTime.UtcNow}) {message}");
                Thread.Sleep(millisecond);
                channel.BasicAck(e.DeliveryTag, false);

            };
            channel.BasicConsume(queueName, false, eventingBasicConsumer);
            Console.ReadLine();
        }

        static void Main(string[] args)
        {

            Start(int.Parse(args[0]));
        }
    }
}
