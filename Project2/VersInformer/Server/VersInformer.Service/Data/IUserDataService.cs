using VersInformer.Common.Entities.Users;
using VersInformer.Service.Data.JsonFileService;

namespace VersInformer.Service.Data
{
    interface IUserDataService
    {
        /// <summary>
        /// Gets the name of the user by user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        SEUser GetUserByUserName(string userName);

        /// <summary>
        /// Validates the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        bool Validate(string userName, string password);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="UserExistsException"></exception>
        SEUser CreateUser(SEUser user, string password);
    }
}
