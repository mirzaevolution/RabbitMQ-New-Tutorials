using System;
using System.Text;
using RabbitMQ.Client;
namespace Producer.Direct
{
    class Program
    {
        private static IConnection _connection;
        private static IModel _model;
        private static string _exchangeName = "exchange-direct";
        private static void Init()
        {
            _connection = new ConnectionFactory()
            {
                HostName = "localhost"
            }.CreateConnection();
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(_exchangeName, ExchangeType.Direct, false, false);
        }
        static Program()
        {
            Init();
        }
        static void Send(string type, string[] messages)
        {
            if(messages!=null && messages.Length> 0)
            {
                foreach(string message in messages)
                {
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    Console.WriteLine($"Sending `{message}`....");
                    _model.BasicPublish(_exchangeName, type,null, messageBytes);

                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter message route-type (1=route-x|2=router-y): ");
            int typeInt = int.Parse(Console.ReadLine()?.Trim());
            string type = string.Empty;
            if(typeInt==1)
            {
                type = "route-x";
            }
            else if(typeInt == 2)
            {
                type = "route-y";
            }
            Console.WriteLine("Enter message, separa0ted by ; for new message: ");
            string messageStr = Console.ReadLine()?.Trim();
            Send(type, messageStr.Split(";", StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine("Press [ENTER] to quit");
            Console.ReadLine();
        }
    }
}
