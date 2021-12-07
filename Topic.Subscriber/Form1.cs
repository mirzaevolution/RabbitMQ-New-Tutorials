using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace Topic.Subscriber
{
    public partial class formExchangeTopicSubscribers : Form
    {
        private IConnection _connection;
        private IModel _channel;
        private string _exchangeName = "exchange-topic";
        private string _queueuLogCustomer = "logs.customer.v2";
        private string _queueLogOrder = "logs.order.v2";
        private void InitializeRabbitMQ()
        {
            try
            {
                _connection = new ConnectionFactory()
                {
                    HostName = "localhost"
                }.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(_exchangeName, ExchangeType.Topic, durable: true);
                _channel.QueueDeclare(_queueuLogCustomer, durable: true, autoDelete: false);
                _channel.QueueDeclare(_queueLogOrder, durable: true, autoDelete: false);
                _channel.QueueBind(_queueuLogCustomer, _exchangeName, RouteKeyConstants.LogCustomerCreated);
                _channel.QueueBind(_queueuLogCustomer, _exchangeName, RouteKeyConstants.LogCustomerUpdated);
                _channel.QueueBind(_queueLogOrder, _exchangeName, RouteKeyConstants.LogOrderAnyCompleted);

                EventingBasicConsumer basicEvent = new EventingBasicConsumer(_channel);
                basicEvent.Received += MessageReceived;
                _channel.BasicQos(0, 1, false);
                _channel.BasicConsume(_queueuLogCustomer, true, basicEvent);
                _channel.BasicConsume(_queueLogOrder, true, basicEvent);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MessageReceived(object sender, BasicDeliverEventArgs e)
        {
            string decodedMessage = Encoding.UTF8.GetString(e.Body.ToArray());
            switch (e.RoutingKey)
            {
                case RouteKeyConstants.LogCustomerCreated:
                    {
                        listBoxLogsCustomerCreated.Items.Add($"[{DateTime.Now}] {decodedMessage}");
                        break;
                    }
                case RouteKeyConstants.LogCustomerUpdated:
                    {
                        listBoxLogsCustomerUpdated.Items.Add($"[{DateTime.Now}] {decodedMessage}");

                        break;
                    }
                default:
                    {
                        string orderId = e.RoutingKey.Replace("logs.order.", "").Replace(".completed","");
                        listBoxLogsOrderAnyCompleted.Items.Add($"[{DateTime.Now} - {orderId}] {decodedMessage}");


                        break;
                    }
            }
        }

        public formExchangeTopicSubscribers()
        {
            InitializeComponent();
            InitializeRabbitMQ();
        }

    }
}
