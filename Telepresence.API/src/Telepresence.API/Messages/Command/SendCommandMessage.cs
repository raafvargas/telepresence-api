using System;
using System.Runtime.Serialization;

namespace Telepresence.API.Messages.Command
{
    /// <summary>
    /// Message to send commants to Robots
    /// </summary>
    [DataContract]
    public class SendCommandMessage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="axisX">Movement in axis X</param>
        /// <param name="axisY">Movement in axis Y</param>
        public SendCommandMessage(string axisX, string axisY)
        {
            AxisX = axisX;
            AxisY = axisY;
            SentAt = DateTime.Now;
        }

        /// <summary>
        /// Movement in axis X
        /// </summary>
        [DataMember]
        public string AxisX { get; private set; }

        /// <summary>
        /// Movement in axis Y
        /// </summary>
        [DataMember]
        public string AxisY { get; private set; }

        /// <summary>
        /// When the message was sent
        /// </summary>
        [DataMember]
        public DateTime SentAt { get; private set; }
    }
}
