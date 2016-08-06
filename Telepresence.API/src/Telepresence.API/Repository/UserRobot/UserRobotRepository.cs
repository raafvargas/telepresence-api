using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Telepresence.API.Repository.Base;

namespace Telepresence.API.Repository.UserRobot
{
    public class UserRobotRepository : DocumentDbRespository<Models.Telepresence.UserRobot>, IUserRobotRepository
    {
        public UserRobotRepository() : base("Telepresence", "UserRobot") { }

        public async Task SaveAssociationAsync(Models.Telepresence.UserRobot userRobot)
        {
            await Save(userRobot);
        }

        public async Task<ICollection<Models.Telepresence.UserRobot>> GetAsync(Expression<Func<Models.Telepresence.UserRobot, bool>> expression)
        {
            return await Query(expression);
        }
    }
}
