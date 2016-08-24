using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telepresence.API.Dependency;

namespace Telepresence.API.MessageBroker
{
    /// <summary>
    /// Message broker default interface
    /// </summary>
    public interface IMessageBroker : IDependencyResolver
    {
        /// <summary>
        /// Publish a message to the broker
        /// </summary>
        /// <typeparam name="TMessage">Message type</typeparam>
        /// <param name="message">Message</param>
        /// <param name="queue">Message destination queue</param>
        /// <returns></returns>
        void Publish<TMessage>(string queue, TMessage message);
    }
}
