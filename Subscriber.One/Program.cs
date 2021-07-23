using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscriber.One
{
    class Program
    {
        private static IConnection _connection;
        static void InitConnection()
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
        static IModel InitChannelModel()
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
        static void Main(string[] args)
        {
            if (_connection != null)
            {
                IModel channel = InitChannelModel();
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                consumer.Received += (s, e) =>
                {
                    string message = Encoding.UTF8.GetString(e.Body.ToArray());
                    Console.Write($"[{DateTime.Now}] {message}");
                    
                    //to simulate long running task
                    Thread.Sleep(5000); 

                    Console.WriteLine(" [!]");
                    channel.BasicAck(e.DeliveryTag, false);
                };
                channel.BasicConsume(queue: "queue-one", autoAck: false, consumer);
            }
            else
            {
                Console.WriteLine("Cannot initialize connection!");
            }
            Console.ReadLine();
        }
    }
}
