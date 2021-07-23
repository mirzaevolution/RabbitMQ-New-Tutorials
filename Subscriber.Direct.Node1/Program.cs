using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscriber.Direct.Node1
{
    class Program
    {
        private static IConnection _connection;
        private static IModel _model;
        private static string _exchangeName = "exchange-direct";
        private static string _queueName = string.Empty;
        private static string _routingKey = "route-x";
        private static void Init()
        {
            _connection = new ConnectionFactory()
            {
                HostName = "localhost"
            }.CreateConnection();
            _model = _connection.CreateModel();
            _queueName = _model.QueueDeclare(exclusive:true).QueueName;
            _model.ExchangeDeclare(_exchangeName, ExchangeType.Direct, false, false);
            _model.QueueBind(_queueName, _exchangeName, _routingKey);
            EventingBasicConsumer consumer = new EventingBasicConsumer(_model);
            consumer.Received += (s, e) =>
            {
                string message = Encoding.UTF8.GetString(e.Body.ToArray());
                Console.WriteLine($"[{DateTime.Now} - {e.RoutingKey}] {message}");
            };
            Console.WriteLine($"Listening on {_queueName}");
            _model.BasicConsume(_queueName, true, consumer);
            _model.BasicQos(prefetchSize: 0, prefetchCount: 1, false);

        }
        static void Main(string[] args)
        {
            Init();
            Console.ReadLine();
        }
    }
}
