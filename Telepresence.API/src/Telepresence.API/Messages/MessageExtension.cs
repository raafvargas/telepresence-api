using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telepresence.API.Messages
{
    public static class MessageExtension
    {
        public static async Task<EventData> GetAsEventData(this object message)
        {
            var json = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(message));

            return new EventData(Encoding.UTF8.GetBytes(json));
        }
    }
}
