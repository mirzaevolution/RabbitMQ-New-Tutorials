using System;
using System.Text;
using RabbitMQ.Client;
namespace Publisher.FanOut
{
    class Program
    {
        private static IConnection _connection;
        private static IModel _model;
        static void InitConnection()
        {
            _connection = new ConnectionFactory()
            {
                HostName = "localhost"
            }.CreateConnection();
        }
        static Program()
        {
            InitConnection();
        }
        static IModel GetModel()
        {
            if(_model == null)
            {
                _model = _connection.CreateModel();
                
                _model.ExchangeDeclare("exchange-fanout", ExchangeType.Fanout, durable: false);

            }
            return _model;
        }
        static void SendMessage(string[] messages)
        {
            IModel model = GetModel();
            foreach(string message in messages)
            {
                try
                {
                    byte[] messageByte = Encoding.UTF8.GetBytes(message);
                    model.BasicPublish("exchange-fanout", "", null, messageByte);
                    Console.WriteLine($"`{message}` is sent.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERR: {ex.Message}");
                }
            }
        }
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                SendMessage(args);
            }
        }
    }
}
