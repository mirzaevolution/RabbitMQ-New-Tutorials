using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Windows.Markup;

namespace TopicRouting.Receiver
{
    class Program
    {
        private static IConnection _connection;
        private static IModel _model;
        private static string _exchangeName = "rewind.topicrouting";
        private static void Init()
        {
            try
            {
                
                _connection = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672
                }.CreateConnection();

                _model = _connection.CreateModel();
                _model.ExchangeDeclare(_exchangeName, ExchangeType.Topic, durable: true, autoDelete: false);

                string allTrxRoutingKey = "trx.#";
                string orderTrxRoutingKey = "trx.order.*";
                string paymentTrxRoutingKey = "trx.payment.*";

                string queueAllTrx = _model.QueueDeclare().QueueName;
                string queueOrderTrx = _model.QueueDeclare().QueueName;
                string queuePaymentTrx = _model.QueueDeclare().QueueName;


                _model.QueueBind(queueAllTrx, _exchangeName, allTrxRoutingKey);
                _model.QueueBind(queueOrderTrx, _exchangeName, orderTrxRoutingKey);
                _model.QueueBind(queuePaymentTrx, _exchangeName, paymentTrxRoutingKey);


                EventingBasicConsumer allTrxConsumer = new EventingBasicConsumer(_model);
                EventingBasicConsumer orderTrxConsumer = new EventingBasicConsumer(_model);
                EventingBasicConsumer paymentTrxConsumer = new EventingBasicConsumer(_model);
                allTrxConsumer.Received += (s, e) =>
                {
                    string body = Encoding.UTF8.GetString(e.Body.ToArray());
                    Console.WriteLine($"[{allTrxRoutingKey}/{e.RoutingKey}]: {body}");
                    _model.BasicAck(deliveryTag: e.DeliveryTag, multiple: true);
                };
                orderTrxConsumer.Received += (s, e) =>
                {
                    string body = Encoding.UTF8.GetString(e.Body.ToArray());
                    Console.WriteLine($"[{orderTrxRoutingKey}/{e.RoutingKey}]: {body}");
                    _model.BasicAck(deliveryTag: e.DeliveryTag, multiple: true);
                };
                paymentTrxConsumer.Received += (s, e) =>
                {
                    string body = Encoding.UTF8.GetString(e.Body.ToArray());
                    Console.WriteLine($"[{paymentTrxRoutingKey}/{e.RoutingKey}]: {body}");
                    _model.BasicAck(deliveryTag: e.DeliveryTag, multiple: true);
                };

                _model.BasicConsume(queueAllTrx, false, allTrxConsumer);
                _model.BasicConsume(queueOrderTrx, false, orderTrxConsumer);
                _model.BasicConsume(queuePaymentTrx, false, paymentTrxConsumer);

                Console.WriteLine("Press ENTER to quit");
                Console.ReadLine();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void Main(string[] args)
        {
            Init();
        }
    }
}
