using RabbitMQ.Client;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DirectRouting.Sender
{
    public partial class MainWindow : Window
    {
        private static IConnection _connection;
        private static IModel _model;
        private IBasicProperties _sharedMessageProperties;
        private readonly string _exchangeName = "rewind.directrouting";
        private readonly string _routingKey1 = "receiver1";
        private readonly string _routingKey2 = "receiver2";


        public MainWindow()
        {
            InitializeComponent();
            CreateConnection();

        }

        private void ShowError(string text, string title = "Error")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CreateConnection()
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
                _sharedMessageProperties = _model.CreateBasicProperties();
                _sharedMessageProperties.Persistent = true;

            }
            catch(Exception ex)
            {
                DisableAllControls();
                ShowError(ex.Message);

            }
        }

        private void DisableAllControls()
        {
            foreach(Control control in new Control[]
            {
                TextBoxMessage,
                ButtonSendReceiver1,
                ButtonSendReceiver2
            })
            {
                control.IsEnabled = false;
            }
        }

        private void OnSendReceiver1Clicked(object sender, RoutedEventArgs e)
        {
            SendMessage(_routingKey1);
        }

        private void OnSendReceiver2Clicked(object sender, RoutedEventArgs e)
        {
            SendMessage(_routingKey2);
        }

        private void SendMessage(string routingKey)
        {
            string message = TextBoxMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                try
                {

                    _model.BasicPublish(_exchangeName, routingKey, _sharedMessageProperties, Encoding.UTF8.GetBytes(message));
                    MessageBox.Show("Message sent", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    TextBoxMessage.Text = "";
                }
                catch(Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
            else
            {
                ShowError("Please enter the message first!","Validation Error");
            }
        }

    }
}
