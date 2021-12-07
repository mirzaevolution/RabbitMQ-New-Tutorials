using RabbitMQ.Client;
using System;
using System.Text;

namespace Fanout.Sender
{
    class Program
    {
        const string ExchangeName = "logs";
        private static IConnection _connection;
        private static IModel _model;
        private static IBasicProperties _basicProperties;
        private static bool _isError = false;
        static void Init()
        {
            try
            {
                Console.WriteLine("Starting connection...");
                _connection = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672
                }.CreateConnection();
                Console.WriteLine("Connection started.");
                Console.WriteLine("Creating model...");
                _model = _connection.CreateModel();
                _model.ExchangeDeclare(ExchangeName, ExchangeType.Fanout, durable: true, autoDelete: false);
                _basicProperties = _model.CreateBasicProperties();
                _basicProperties.Persistent = true;
                Console.WriteLine("Model created. Press CTRL+C to quit");
            }
            catch(Exception ex)
            {
                _isError = true;
                Console.WriteLine(ex);
            }
        }
        static void StartMessageLooping()
        {
            if (_isError)
                return;
            string message = string.Empty;
            do
            {
                try
                {
                    Console.Write("> ");
                    message = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(message))
                    {
                        _model.BasicPublish(ExchangeName, "", _basicProperties, Encoding.UTF8.GetBytes(message));
                    }
                }
                catch(Exception ex)
                {
                    _isError = true;
                    Console.WriteLine(ex);
                }
            } while (!_isError);
        }
        static void Main(string[] args)
        {
            Init();
            StartMessageLooping();
        }
    }
}
