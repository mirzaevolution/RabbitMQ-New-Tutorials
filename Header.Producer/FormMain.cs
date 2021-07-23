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


namespace Header.Producer
{
    public partial class FormMain : Form
    {
        private IConnection _connection;
        private IModel _model;
        private IDictionary<string, KeyValuePair<string,string>[]> _queueKeys = new Dictionary<string, KeyValuePair<string,string>[]>
        {
            { TagConstants.CustomerCreated, new KeyValuePair<string, string>[] 
                {
                    new KeyValuePair<string, string>("type","customer"),
                    new KeyValuePair<string, string>("event","created"),
                    new KeyValuePair<string, string>("x-match","all")
                } 
            },
            { 
                TagConstants.CustomerUpdated, 
                new KeyValuePair<string, string>[]
                {
                    new KeyValuePair<string, string>("type","customer"),
                    new KeyValuePair<string, string>("event","updated"),
                    new KeyValuePair<string, string>("x-match","any")
                }
            },
            { 
                TagConstants.CustomerDeleted, 
                new KeyValuePair<string, string>[]
                {
                    new KeyValuePair<string, string>("type","customer"),
                    new KeyValuePair<string, string>("event","deleted"),
                    new KeyValuePair<string, string>("x-match","all")
                }
            },
            {
                TagConstants.OrderPlaced,
                new KeyValuePair<string, string>[]
                {
                    new KeyValuePair<string, string>("type","order"),
                    new KeyValuePair<string, string>("event","placed"),
                    new KeyValuePair<string, string>("x-match","all")
                }
            }
        };
        private string _exchangeName = "exchange.header";
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public FormMain()
        {
            InitializeComponent();
            this.buttonCustomerCreated.Click += OnMessageBroadcasted;
            this.buttonCustomerUpdated.Click += OnMessageBroadcasted;
            this.buttonCustomerDeleted.Click += OnMessageBroadcasted;
            this.buttonOrderPlaced.Click += OnMessageBroadcasted;
        }

        private void OnMessageBroadcasted(object sender, EventArgs e)
        {
            string message = textBoxMessage.Text?.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Message cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            Button button = sender as Button;
            if (button != null)
            {
                SendMessage(button.Tag.ToString(), message);
                textBoxMessage.Text = string.Empty;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitializeRabbitMQConnection();
        }
        private void SendMessage(string type, string message)
        {
            try
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                var kvp = _queueKeys[type];

                IBasicProperties basicProperties =
                    _model.CreateBasicProperties();
                basicProperties.Headers = new Dictionary<string, object>();
                foreach(var item in kvp)
                {
                    basicProperties.Headers.Add(item.Key, item.Value);
                }
                _model.BasicPublish(_exchangeName, "", basicProperties, messageBytes);

                MessageBox.Show("Message sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
