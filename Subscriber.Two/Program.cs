using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscriber.Two
{
    class Program
    {
        static void ReceiveMessage()
        {
            using(IConnection connection = new ConnectionFactory
            {
               HostName = "localhost",
               Port = 5672
            }.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "queue-durable", durable: true, exclusive: false, autoDelete: false);
                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (s, e) =>
                    {
                        string message = Encoding.UTF8.GetString(e.Body.ToArray());
                        Console.WriteLine($"[{DateTime.Now}] {message}");
                        channel.BasicAck(e.DeliveryTag, false);
                    };
                    channel.BasicConsume(queue: "queue-durable", autoAck: false, consumer);
                    Console.ReadLine();
                }
            }
        }
        static void Main(string[] args)
        {
            ReceiveMessage();

        }
    }
}
