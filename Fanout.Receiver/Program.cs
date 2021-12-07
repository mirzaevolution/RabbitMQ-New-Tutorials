using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Fanout.Receiver
{
    class Program
    {
        const string ExchangeName = "logs";
        private static IConnection _connection;
        private static IModel _model;
        private static IBasicProperties _basicProperties;
        private static bool _isError = false;
        private static string _queueName = "";
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
                Console.WriteLine("Model created.");
                _model.ExchangeDeclare(ExchangeName, ExchangeType.Fanout, durable: true, autoDelete: false);
                _queueName = _model.QueueDeclare().QueueName;
                _model.QueueBind(_queueName,ExchangeName,"");
                _basicProperties = _model.CreateBasicProperties();
                _basicProperties.Persistent = true;
                Console.WriteLine($"Queue '{_queueName}' bound to exchange '{ExchangeName}'");
                Console.WriteLine("Press CTRL+C to quit\n");
                
                
            }
            catch (Exception ex)
            {
                _isError = true;
                Console.WriteLine(ex);
            }
        }
        static void Receive()
        {
            if (_isError)
                return;
            EventingBasicConsumer consumer = new EventingBasicConsumer(_model);
            consumer.Received += OnMessageReceived;
            _model.BasicConsume(_queueName, false, consumer);
            Console.ReadLine();
        }

        private static void OnMessageReceived(object sender, BasicDeliverEventArgs e)
        {
            string body = Encoding.UTF8.GetString(e.Body.ToArray());
            Console.WriteLine($"[@{DateTime.Now}]: {body}");
        }

        static void Main(string[] args)
        {
            Init();
            Receive();
        }
    }
}
