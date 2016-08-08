using Microsoft.ServiceBus;
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
    /// Service Manager to User and Robots
    /// </summary>
    public class UserRobotService : IUserRobotService
    {
        private readonly string _namespaceConnectionString = "Endpoint=sb://telepresence-commands-ns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gaPsGEQONLY2OLphaQ2EZ5YKCx2q+0uVgwvJkqCuC4g=";
        private readonly IUserRobotRepository _repository;
        private readonly NamespaceManager _namespaceManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Dependent repository</param>
        public UserRobotService(IUserRobotRepository repository)
        {
            _repository = repository;

            var token = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                "RootManageSharedAccessKey",
                "gaPsGEQONLY2OLphaQ2EZ5YKCx2q+0uVgwvJkqCuC4g=");

            _namespaceManager = new NamespaceManager(
                "sb://telepresence-commands-ns.servicebus.windows.net",
                token);
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
                var association = await _repository.GetAsync(ass => ass.RobotId == request.RobotId && ass.Active);

                if (association.Any())
                    throw new Exception("Robot isn't avaliable to association");

                await _repository.SaveAssociationAsync(new Models.Telepresence.UserRobot
                {
                    Active = request.Active,
                    AssociationExpires = request.AssociationExpires,
                    UserId = request.UserId,
                    RobotId = request.RobotId
                });
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
        /// <param name="robotId">Robot Id</param>
        /// <returns></returns>
        public async Task<SendCommandResponse> SendCommandAsync(string robotId, SendCommandRequest request)
        {
            var response = new SendCommandResponse();

            if (!await RobotAssociateToUser(robotId, request.UserId))
                throw new Exception("Association beetwen robot and user doesn't exists or is unavailiable.");

            await _namespaceManager.CreateEventHubIfNotExistsAsync(GetEventHubPath(robotId));

            var eventHubClient = EventHubClient.CreateFromConnectionString(_namespaceConnectionString, GetEventHubPath(robotId));

            var message = new SendCommandMessage(request.AxisX, request.AxisY);

            await eventHubClient.SendAsync(
                await message.GetAsEventData());

            response.Success = true;

            return response;
        }

        private async Task<bool> RobotAssociateToUser(string robotId, string userId)
        {
            var association = await _repository.GetAsync(ass => ass.RobotId == robotId && ass.UserId == userId);

            return association.FirstOrDefault() != null;
        }

        private string GetEventHubPath(string robotId)
        {
            return $"RobotId-{robotId}".ToLowerInvariant();
        }
    }
}
