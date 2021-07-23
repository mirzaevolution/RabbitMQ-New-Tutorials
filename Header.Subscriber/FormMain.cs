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
namespace Header.Subscriber
{
    public partial class FormMain : Form
    {
        private string _exchangeName = "exchange.header";
        private IConnection _connection;
        private IModel _model;

        private void InitializeRabbitMQConnection()
        {
            try
            {
                _connection = new ConnectionFactory
                {
                    HostName = "localhost"
                }.CreateConnection();
                _model = _connection.CreateModel();
                _model.ExchangeDeclare(_exchangeName, ExchangeType.Headers, durable: true);
                
                _model.QueueDeclare(QueueConstants.CustomerCreated.Key, true, false, false, null);
                _model.QueueDeclare(QueueConstants.CustomerUpdated.Key, true, false, false, null);
                _model.QueueDeclare(QueueConstants.CustomerDeleted.Key, true, false, false, null);
                _model.QueueDeclare(QueueConstants.OrderPlaced.Key, true, false, false, null);

                _model.QueueBind(QueueConstants.CustomerCreated.Key, _exchangeName, "", QueueConstants.CustomerCreated.Value);
                _model.QueueBind(QueueConstants.CustomerUpdated.Key, _exchangeName, "", QueueConstants.CustomerUpdated.Value);
                _model.QueueBind(QueueConstants.CustomerDeleted.Key, _exchangeName, "", QueueConstants.CustomerDeleted.Value);
                _model.QueueBind(QueueConstants.OrderPlaced.Key, _exchangeName, "", QueueConstants.OrderPlaced.Value);

                EventingBasicConsumer costumerCreated = new EventingBasicConsumer(_model);
                costumerCreated.Received += OnCustomerCreated;

                EventingBasicConsumer costumerUpdated = new EventingBasicConsumer(_model);
                costumerUpdated.Received += OnCustomerUpdated;


                EventingBasicConsumer customerDeleted = new EventingBasicConsumer(_model);
                customerDeleted.Received += OnCustomerDeleted;

                EventingBasicConsumer orderPlaced = new EventingBasicConsumer(_model);
                orderPlaced.Received += OnOrderPlaced;

                _model.BasicQos(0, 1,false);
                _model.BasicConsume(QueueConstants.CustomerCreated.Key, true, costumerCreated);
                _model.BasicConsume(QueueConstants.CustomerUpdated.Key, true, costumerUpdated);
                _model.BasicConsume(QueueConstants.CustomerDeleted.Key, true, customerDeleted);
                _model.BasicConsume(QueueConstants.OrderPlaced.Key, true, orderPlaced);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnOrderPlaced(object sender, BasicDeliverEventArgs e)
        {
            string decodedMessage = Encoding.UTF8.GetString(e.Body.ToArray());
            listBoxLogsOrderPlaced.Invoke(new Action(() =>
            {
                listBoxLogsOrderPlaced.Items.Add($"[{DateTime.Now}] {decodedMessage}");
            }));
                 
        }

        private void OnCustomerDeleted(object sender, BasicDeliverEventArgs e)
        {
            string decodedMessage = Encoding.UTF8.GetString(e.Body.ToArray());
            listBoxLogsCustomerDeleted.Invoke(new Action(() =>
            {
                listBoxLogsCustomerDeleted.Items.Add($"[{DateTime.Now}] {decodedMessage}");

            }));


        }

        private void OnCustomerUpdated(object sender, BasicDeliverEventArgs e)
        {
            string decodedMessage = Encoding.UTF8.GetString(e.Body.ToArray());
            listBoxLogsCustomerUpdated.Invoke(new Action(() =>
            {
                listBoxLogsCustomerUpdated.Items.Add($"[{DateTime.Now}] {decodedMessage}");

            }));
        }

        private void OnCustomerCreated(object sender, BasicDeliverEventArgs e)
        {
            string decodedMessage = Encoding.UTF8.GetString(e.Body.ToArray());
            listBoxLogsCustomerCreated.Invoke(new Action(() =>
            {
                listBoxLogsCustomerCreated.Items.Add($"[{DateTime.Now}] {decodedMessage}");
            }));
        }

        public FormMain()
        {
            InitializeComponent();
            InitializeRabbitMQConnection();
        }
    }
}
