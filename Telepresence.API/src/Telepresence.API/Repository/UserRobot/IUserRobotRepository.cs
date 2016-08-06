using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Telepresence.API.Dependency;

namespace Telepresence.API.Repository.UserRobot
{
    public interface IUserRobotRepository : IDependencyResolver
    {
        Task SaveAssociationAsync(Models.Telepresence.UserRobot userRobot);

        Task<ICollection<Models.Telepresence.UserRobot>> GetAsync(Expression<Func<Models.Telepresence.UserRobot, bool>> expression);
    }
}
