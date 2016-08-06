using Microsoft.ServiceBus.Messaging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telepresence.API.Contract.UserRobot;
using Telepresence.API.Messages;
using Telepresence.API.Messages.Command;
using Telepresence.API.Repository.UserRobot;

namespace Telepresence.API.Services.UserRobot
{
    /// <summary>
    /// Service Managet to User and Robots
    /// </summary>
    public class UserRobotService : IUserRobotService
    {
        private readonly string _eventHubKey;
        private readonly string _eventHubPath;
        private readonly string _eventHubEndpoint;
        private readonly IUserRobotRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Dependent repository</param>
        public UserRobotService(IUserRobotRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Associates an user as robot controller
        /// </summary>
        /// <param name="request">Infos about robot and user</param>
        /// <returns></returns>
        public async Task<AssociateUserRobotResponse> AssociateAsync(AssociateUserRobotRequest request)
        {
            var response = new AssociateUserRobotResponse();

            try
            {
                var association = await _repository.GetAsync(ass => ass.RobotId == request.UserRobot.RobotId && ass.Active);

                if (association.Any())
                    throw new Exception("Robot isn't avaliable to association");

                await _repository.SaveAssociationAsync(request.UserRobot);
                response.Success = true;
            }
            catch
            {
                response.Success = false;
            }

            return response;
        }

        /// <summary>
        /// Send the user command for the robot
        /// </summary>
        /// <param name="request">Command</param>
        /// <returns></returns>
        public async Task<SendCommandResponse> SendCommandAsync(SendCommandRequest request)
        {
            var response = new SendCommandResponse();

            try
            {
                if (!await RobotAvaliableToAssociation(request.RobotId, request.UserId))
                    throw new Exception("Association beetwen robot and user doesn't exists or is unavailiable.");

                var eventHubClient = EventHubClient.CreateFromConnectionString(_eventHubEndpoint, _eventHubPath);

                var message = new SendCommandMessage(request.AxisX, request.AxisY);

                await eventHubClient.SendAsync(
                    await message.GetAsEventData());

                response.Success = true;
            }
            catch
            {
                response.Success = false;
            }

            return response;
        }

        private async Task<bool> RobotAvaliableToAssociation(string robotId, string userId)
        {
            var association = await _repository.GetAsync(ass => ass.RobotId == robotId && ass.UserId == userId);

            return association == null;
        }
    }
}
