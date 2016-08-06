using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Telepresence.API.Dependency;

namespace Telepresence.API.Repository.Robot
{
    /// <summary>
    /// Robot Repository
    /// </summary>
    public interface IRobotRepository : IDependencyResolver
    {
        /// <summary>
        /// Regiter a robot
        /// </summary>
        /// <param name="robot">Robot info</param>
        /// <returns>Registered robot</returns>
        Task<string> RegisterAsync(Models.Robot robot);

        /// <summary>
        /// Gets a robot
        /// </summary>
        /// <param name="id">Robot Id</param>
        /// <returns>The robot</returns>
        Task<Models.Robot> GetAsync(string id);

        /// <summary>
        /// Gets a robot by the expression
        /// </summary>
        /// <param name="predicate">expression</param>
        /// <returns>The found robot</returns>
        Task<Models.Robot> GetAsync(Expression<Func<Models.Robot, bool>> predicate);
    }
}
