using System;
using System.Text;
using RabbitMQ.Client;
namespace Producer.Two
{
    class Program
    {
        static void Init(string message = "hello world")
        {
            using (IConnection connection = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672
            }.CreateConnection())
            {
                using(IModel model = connection.CreateModel())
                {
                    byte[] body = Encoding.UTF8.GetBytes(message);
                    model.QueueDeclare(queue: "queue-durable", durable: true, exclusive: false, autoDelete: false);
                    IBasicProperties basicProperties =
                        model.CreateBasicProperties();
                    basicProperties.Persistent = true;
                    try
                    {
                        model.BasicPublish(exchange: "",
                        routingKey: "queue-durable",
                        basicProperties: basicProperties,
                        body: body);
                        Console.WriteLine("Message sent");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                        Console.ReadLine();

                    }
                }
            }
            
        }
        static void Main(string[] args)
        {
            Init($"Hello World at {DateTime.Now}");
        }
    }
}
