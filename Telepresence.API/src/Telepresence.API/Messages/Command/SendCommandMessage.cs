namespace Telepresence.API.Messages.Command
{
    public class SendCommandMessage
    {
        public SendCommandMessage(string axisX, string axisY)
        {
            AxisX = axisX;
            AxisY = axisY;
        }

        public string AxisX { get; private set; }

        public string AxisY { get; private set; }
    }
}
