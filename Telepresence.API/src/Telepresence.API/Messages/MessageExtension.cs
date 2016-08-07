using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Telepresence.API.Messages
{
    /// <summary>
    /// Exentsion to transform messages in Event Data
    /// </summary>
    public static class MessageExtension
    {
        /// <summary>
        /// Transform messages in Event Data
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<EventData> GetAsEventData(this object message)
        {
            var json = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(message));

            return new EventData(Encoding.UTF8.GetBytes(json));
        }
    }
}
