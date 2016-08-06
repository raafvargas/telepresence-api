using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Telepresence.API.Repository.Base;

namespace Telepresence.API.Repository.Robot
{
    /// <summary>
    /// Robots repository
    /// </summary>
    public class RobotRepository : DocumentDbRespository<Models.Robot>, IRobotRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RobotRepository() : base("Telepresence", "Robot") {  }

        /// <summary>
        /// Register a robot
        /// </summary>
        /// <param name="robot">Robot specifications</param>
        /// <returns></returns>
        public async Task<string> RegisterAsync(Models.Robot robot)
        {
            return await Save(robot);
        }

        /// <summary>
        /// Gets a robot by ID
        /// </summary>
        /// <param name="id">Robot ID</param>
        /// <returns></returns>
        public async Task<Models.Robot> GetAsync(string id)
        {
            return await Get(id);
        }

        /// <summary>
        /// Gets a robot by the expression
        /// </summary>
        /// <param name="predicate">expression</param>
        /// <returns>The found robot</returns>
        public async Task<Models.Robot> GetAsync(Expression<Func<Models.Robot, bool>> predicate)
        {
            var robots = await Query(predicate);

            return robots.FirstOrDefault();
        }
    }
}
