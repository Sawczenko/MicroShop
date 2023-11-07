using MicroShop.Core.Errors;
using System.Net;

namespace MicroShop.IdentityService.Application.Errors.Authentication
{
    public class AuthenticationErrors : Error
    {

        #region ErrorDefinitions

        public static readonly Error MICROSHOP_USER_DOES_NOT_EXIST = new ErrorMicroShopUserDoesNotExist();

        #endregion 

        public override string Message { get; }
        public override HttpStatusCode HttpStatusCode { get; }

        public AuthenticationErrors(string name, int value) : base(name, value) { }

        private sealed class ErrorMicroShopUserDoesNotExist : Error
        {
            public override string Message => "User {0} doesn't exist.";
            public override HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;

            public ErrorMicroShopUserDoesNotExist() : base(nameof(MICROSHOP_USER_DOES_NOT_EXIST), 2000)
            {
            }
        }
    }
}
