using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Telepresence.API.Repository.Base;

namespace Telepresence.API.Repository.UserRobot
{
    /// <summary>
    /// UserRobotRepository
    /// </summary>
    public class UserRobotRepository : DocumentDbRespository<Models.Telepresence.UserRobot>, IUserRobotRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserRobotRepository() : base("Telepresence", "UserRobot") { }

        /// <summary>
        /// Saves an association between User and Robot
        /// </summary>
        /// <param name="userRobot"></param>
        /// <returns></returns>
        public async Task SaveAssociationAsync(Models.Telepresence.UserRobot userRobot)
        {
            await Save(userRobot);
        }

        /// <summary>
        /// Get an association between User and Robot
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<ICollection<Models.Telepresence.UserRobot>> GetAsync(Expression<Func<Models.Telepresence.UserRobot, bool>> expression)
        {
            return await Query(expression);
        }
    }
}
