using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

namespace TopicRouting.Sender
{
    class Program
    {
        private static IConnection _connection;
        private static IModel _model;
        private static IBasicProperties _basicProperties;
        private static string _exchangeName = "rewind.topicrouting";
        private static bool _connectSuccess = true;
        private static void Init()
        {
            try
            {
                _connection = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672
                }.CreateConnection();
                
                _model =  _connection.CreateModel();
                _model.ExchangeDeclare(_exchangeName, ExchangeType.Topic, durable: true, autoDelete: false);
                _basicProperties = _model.CreateBasicProperties();
                _basicProperties.Persistent = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                _connectSuccess = false;
            }
        }

        private static void MessageLoop()
        {
            if (!_connectSuccess)
            {
                return;
            }
            string routingKey = string.Empty;
            string message = string.Empty;
            string input = string.Empty;
            Console.Write("Enter message (topic_routing_key:message_to_send)");
            Console.WriteLine("Press ENTER to quit");

            do
            {
                Console.Write("> ");
                input = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(input))
                {
                    string[] inputArray = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    if(inputArray.Length == 2)
                    {
                        routingKey = inputArray.FirstOrDefault();
                        message = inputArray.LastOrDefault();
                        _model.BasicPublish(_exchangeName, routingKey, _basicProperties, Encoding.UTF8.GetBytes(message));
                    }
                }
            } while (true);
        }

        static void Main(string[] args)
        {
            Init();
            MessageLoop();
        }
    }
}
