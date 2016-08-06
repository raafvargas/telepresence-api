namespace Telepresence.API.Contract.UserRobot
{
    public class SendCommandRequest
    {
        public string AxisX { get; set; }

        public string AxisY { get; set; }

        public string RobotId { get; set; }

        public string UserId { get; set; }
    }
}
