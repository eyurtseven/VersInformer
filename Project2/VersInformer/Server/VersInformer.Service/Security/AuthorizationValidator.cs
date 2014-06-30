using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VersInformer.Common.IoC;
using VersInformer.Service.Helpers;

namespace VersInformer.Service.Security
{
    public class AuthorizationValidator : UserNamePasswordValidator
    {
        private IUserManager _userManager;

        public AuthorizationValidator()
        {
            if (!InitializeHelper.IsInitialized)
            {
                InitializeHelper.Initialize();
            }

            _userManager = IoCContainer.Instance.Resolve<IUserManager>();
        }


        public override void Validate(string userName, string password)
        {

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))

                throw new SecurityTokenException("Username and password required");


            if (!_userManager.Validate(userName, password))

                throw new FaultException<WrongUserNameOrPasswordException>(new WrongUserNameOrPasswordException(userName, string.Format("Wrong username ({0}) or password ", userName)));

        }

    }
}
