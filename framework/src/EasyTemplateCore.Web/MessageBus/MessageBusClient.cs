using System;
using System.Text;
using System.Text.Json;
using EasyTemplateCore.Dtos.Location.Country;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace EasyTemplateCore.Web.MessageBus
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQHost"],
                Port = int.Parse(configuration["RabbitMQPort"])
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare("trigger", type: ExchangeType.Fanout);

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

        }

        public void PublishNewCountry(CountryDto countryDto)
        {
            var message = JsonSerializer.Serialize(countryDto);

            if (_connection.IsOpen)
            {
                SendMessage(message);
                return;
            }

            throw new Exception("RabbitMQ connection is closed.");
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish("trigger", "", null, body);
        }

        public void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }
    }
}