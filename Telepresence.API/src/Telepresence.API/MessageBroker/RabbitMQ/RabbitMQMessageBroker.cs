using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Telepresence.API.MessageBroker.RabbitMQ
{
    /// <summary>
    /// <see cref="IMessageBroker"/>
    /// </summary>
    public class RabbitMQMessageBroker : IMessageBroker
    {
        private string _rabbitEndpoint = "amqp://dxaelhin:VnmfOgBrGhIJk2bKb6UrpPhRcKh6FtMy@reindeer.rmq.cloudamqp.com/dxaelhin";

        /// <summary>
        /// <see cref="IMessageBroker.Publish{TMessage}(string, TMessage)"/>
        /// </summary>
        public void Publish<TMessage>(string queue, TMessage message)
        {
            var factory = new ConnectionFactory()
            {
                Uri = _rabbitEndpoint
            };

            using (var connection = factory.CreateConnection())
            {                
                using (var channel = connection.CreateModel())
                {
                    channel.ConfirmSelect();

                    channel.ExchangeDeclare(queue, "direct", true, false, null);

                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    
                    var encodedMessage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                    channel.BasicPublish(queue, string.Empty, properties, encodedMessage);
                    channel.Close();
                }
            }
        }
    }
}
