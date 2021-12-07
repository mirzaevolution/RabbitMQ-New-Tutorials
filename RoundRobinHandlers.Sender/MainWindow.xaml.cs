using System;
using System.Text;
using System.Windows;
using RabbitMQ.Client;


namespace RoundRobinHandlers.Sender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _queueName = "round-robin-queue";
        private IConnection _connectionInstance;
        private IModel _channel;
        private IBasicProperties _sharedBasicProperties;


        public MainWindow()
        {
            InitializeComponent();
            InitConnection();
        }

        private void InitConnection()
        {
            try
            {
                _connectionInstance = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672
                }.CreateConnection();
                _channel =  _connectionInstance.CreateModel();
                _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: true);
                _sharedBasicProperties = _channel.CreateBasicProperties();
                _sharedBasicProperties.Persistent = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ButtonSendMessage.IsEnabled = false;
            }
        }

        private void OnSendMessageClicked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxMessage.Text))
            {
                try
                {

                    byte[] payload = Encoding.UTF8.GetBytes(TextBoxMessage.Text);
                    _channel.BasicPublish("", _queueName, _sharedBasicProperties, payload);
                    TextBoxMessage.Text = "";
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
             
            }
            else
            {
                MessageBox.Show("Please enter message to send!", "Validation Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
