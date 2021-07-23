using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Subscriber.FanOut._1
{
    class Program
    {
        private static IConnection _connection;
        private static IModel _model;
        private static string _queueName = string.Empty;
        private static string _xchangeName = "exchange-fanout";
        static void InitConnection()
        {
            _connection = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672
            }.CreateConnection();
        }
        static Program()
        {
            InitConnection();
        }
        static IModel GetModel()
        {
            if (_model == null)
            {
                _model = _connection.CreateModel();
                _queueName = _model.QueueDeclare("", false, false, true).QueueName;
                _model.ExchangeDeclare(_xchangeName, ExchangeType.Fanout, durable: false);
                _model.QueueBind(_queueName, _xchangeName, "");
                _model.BasicQos(0, 1, false);

            }
            Console.WriteLine($"Listening incoming messages on queue: {_queueName}");
            return _model;
        }
        static void InitEvent()
        {
            var model = GetModel();
            EventingBasicConsumer consumer = new EventingBasicConsumer(model);
            consumer.Received += (sender, payload) =>
            {
                string message = Encoding.UTF8.GetString(payload.Body.ToArray());
                Console.WriteLine($"[{DateTime.Now}] {message}");
                Thread.Sleep(2000);
                model.BasicAck(payload.DeliveryTag, false);
            };
            model.BasicConsume(_queueName, false, consumer);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            InitEvent();
        }
    }
}
