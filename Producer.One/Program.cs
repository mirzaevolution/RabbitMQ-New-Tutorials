using System;
using System.Threading.Tasks;
using System.Text;
using RabbitMQ.Client;

namespace Producer.One
{
    class Program
    {
        static IConnection _connection;
        static Program()
        {
            InitConnection();
        }
        static void InitConnection()
        {
            try
            {

                _connection = new ConnectionFactory()
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
        static IModel CreateChannelModel()
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

                Console.Write("Enter message to send: ");
                string message = Console.ReadLine();
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                IModel channel = CreateChannelModel();
                Console.WriteLine("Sending the message....");
                try
                {
                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "queue-one",
                        body: messageBytes
                    );
                    Console.WriteLine("Message sent.");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                Console.WriteLine("Cannot initialize connection!");
            }
            Console.ReadLine();
        }
    }
}
