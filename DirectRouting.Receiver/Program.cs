using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;
namespace DirectRouting.Receiver
{
    class Program
    {


        private static IConnection _connection;
        private static IModel _model;

        private readonly static string _exchangeName = "rewind.directrouting";
        private static string _queueName = string.Empty;
        private readonly static string _routingKey1 = "receiver1";
        private readonly static string _routingKey2 = "receiver2";


        static void InitConnection()
        {
            try
            {
                _connection = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672
                }.CreateConnection();
                _model = _connection.CreateModel();
                _model.ExchangeDeclare(_exchangeName, ExchangeType.Direct, durable: true, autoDelete: false);
                _queueName = _model.QueueDeclare().QueueName;
                _model.QueueBind(_queueName, _exchangeName, _routingKey1);
                _model.QueueBind(_queueName, _exchangeName, _routingKey2);

                EventingBasicConsumer consumer = new EventingBasicConsumer(_model);
                
                consumer.Received += (s, e) =>
                {
                    
                    string message = Encoding.UTF8.GetString(e.Body.ToArray());
                    Console.WriteLine($"[{_queueName}/{e.RoutingKey}@{DateTime.Now}]: {message}");
                    _model.BasicAck(e.DeliveryTag, false);
                };
                
                _model.BasicConsume(_queueName, false, consumer);
                _model.BasicQos(0, 1, false);
                

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.ReadLine();
            }
        }


        static void Main(string[] args)
        {
            InitConnection();
        }
    }
}
