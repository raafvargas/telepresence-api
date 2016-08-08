using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Telepresence.API.Dependency;

namespace Telepresence.API.Repository.UserRobot
{
    /// <summary>
    /// IUserRobotRepository
    /// </summary>
    public interface IUserRobotRepository : IDependencyResolver
    {
        /// <summary>
        /// Saves an association between User and Robot
        /// </summary>
        /// <param name="userRobot">Association information</param>
        /// <returns></returns>
        Task SaveAssociationAsync(Models.Telepresence.UserRobot userRobot);
        
        /// <summary>
        /// Get an association between User and Robot
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<ICollection<Models.Telepresence.UserRobot>> GetAsync(Expression<Func<Models.Telepresence.UserRobot, bool>> expression);
    }
}
