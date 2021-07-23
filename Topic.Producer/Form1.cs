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

namespace Topic.Producer
{

    public partial class formExchangeTopicProducer : Form
    {
        private IConnection _connection;
        private IModel _channel;
        private string _exchangeName = "exchange-topic";
        private void InitializeRabbitMQ()
        {
            try
            {
                _connection = new ConnectionFactory()
                {
                    HostName = "localhost"
                }.CreateConnection();
                _channel =  _connection.CreateModel();
                _channel.ExchangeDeclare(_exchangeName, ExchangeType.Topic, durable: true);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public formExchangeTopicProducer()
        {
            InitializeComponent();
            InitializeRabbitMQ();
            this.buttonLogCustomerCreated.Click += SendMessageHandler;
            this.buttonLogsCustomerUpdated.Click += SendMessageHandler;
            this.buttonLogsOrderAnyCompleted.Click += SendMessageHandler;
        }
        

        private void SendMessageHandler(object sender, EventArgs e)
        {
            string message = textBoxMessage.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please enter the message!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Button button = sender as Button;
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            switch (button.Tag.ToString())
            {
                case RouteKeyConstants.LogCustomerCreated:
                    {
                        _channel.BasicPublish(_exchangeName, RouteKeyConstants.LogCustomerCreated, null, messageBytes);
                        MessageBox.Show("Message sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxMessage.Text = string.Empty;
                        break;
                    }
                case RouteKeyConstants.LogCustomerUpdated:
                    {
                        _channel.BasicPublish(_exchangeName, RouteKeyConstants.LogCustomerUpdated, null, messageBytes);
                        MessageBox.Show("Message sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxMessage.Text = string.Empty;
                        break;
                    }
                case RouteKeyConstants.LogOrderAnyCompleted:
                    {
                        _channel.BasicPublish(_exchangeName, $"logs.order.{Guid.NewGuid().ToString()}.completed", null, messageBytes);
                        MessageBox.Show("Message sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxMessage.Text = string.Empty;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Undefined");
                        break;
                    }
            }
        }

        private void formExchangeTopicProducer_Load(object sender, EventArgs e)
        {
        }
    }
}
