using System;
using System.Text;
using System.Text.Json;
using LateralApp.Dtos.Location.Country;
using LateralApp.MessageBus.Dtos.Location.Country;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace LateralApp.MessageBus.ProduceMessage
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

        public void PublishNewCountry(AddCountryDto addCountry)
        {
            var item = addCountry.ToMessageBusDto();
            item.EventName = "AddCountry";
            var message = JsonSerializer.Serialize(item);

            if (_connection.IsOpen)
            {
                var body = Encoding.UTF8.GetBytes(message);
                _channel.BasicPublish("trigger", "", null, body);
                return;
            }

            throw new Exception("RabbitMQ connection is closed.");
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