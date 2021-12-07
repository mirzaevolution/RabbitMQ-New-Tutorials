using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscriber.One.Ext1
{
    class Program
    {
        private static IConnection _connection;
        private static void InitConnection()
        {
            try
            {
                _connection = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672
                }.CreateConnection();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static Program()
        {
            InitConnection();
        }
        private static IModel CreateChannelModel()
        {
            IModel channel = _connection.CreateModel();
            channel.QueueDeclare(
                    queue: "queue-one",
                    durable: false,
                    exclusive: false,
                    autoDelete: true
                );
            return channel;
        }
        private static void HandleMessage()
        {
            if (_connection != null)
            {
                IModel channel = CreateChannelModel();
                EventingBasicConsumer eventingBasicConsumer = new EventingBasicConsumer(channel);
                eventingBasicConsumer.Received += (s, e) =>
                {
                    byte[] messageBytes = e.Body.ToArray();
                    string message = Encoding.UTF8.GetString(messageBytes);
                    Console.Write($"[Handler#2 {DateTime.Now}] {message}");

                    //to simulate long running task
                    Thread.Sleep(3000);

                    Console.WriteLine(" [!]");
                    channel.BasicAck(e.DeliveryTag, false);
                };
                channel.BasicConsume("queue-one", false, eventingBasicConsumer);
            }
            else
            {
                Console.WriteLine("Connection can't be started");
            }
        }
        static void Main(string[] args)
        {
            HandleMessage();
            Console.ReadLine();
        }
    }
}
