using MicroShop.Core.Errors;
using System.Net;

namespace MicroShop.IdentityService.Application.Errors.Authentication
{
    public class AuthenticationErrors : Error
    {

        #region ErrorDefinitions

        public static readonly Error MICROSHOP_USER_DOES_NOT_EXIST = new ErrorMicroShopUserDoesNotExist();

        public static readonly Error MICROSHOP_USER_PASSWORD_IS_NOT_CORRECT = new ErrorMicroShopUserPasswordIsNotCorrect();

        public static readonly Error MICROSHOP_USER_ALREADY_EXISTS = new ErrorMicroShopUserAlreadyExists();

        public static readonly Error MICROSHOP_USER_CREATION_FAILED = new ErrorMicroShopUserCreationFailed();

        public static readonly Error MICROSHOP_USER_USERNAME_DOES_NOT_MATCH =
            new ErrorMicroShopUserUserNameDoesNotMatch();

        #endregion 

        public override HttpStatusCode HttpStatusCode { get; }

        public AuthenticationErrors(string name, int value) : base(name, value) { }

        private sealed class ErrorMicroShopUserDoesNotExist : Error
        {
            public override HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;

            public ErrorMicroShopUserDoesNotExist() : base(nameof(MICROSHOP_USER_DOES_NOT_EXIST), 2000)
            {
                Message = "User {0} doesn't exist.";
            }
        }


        private sealed class ErrorMicroShopUserPasswordIsNotCorrect : Error
        {
            public override HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;

            public ErrorMicroShopUserPasswordIsNotCorrect() : base(nameof(MICROSHOP_USER_PASSWORD_IS_NOT_CORRECT), 2001)
            {
                Message = "Password for user {0} is not correct.";
            }
        }

        private sealed class ErrorMicroShopUserAlreadyExists : Error
        {
            public override HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;

            public ErrorMicroShopUserAlreadyExists() : base(nameof(MICROSHOP_USER_ALREADY_EXISTS), 2002)
            {
                Message = "User {0} already exists.";
            }
        }

        private sealed class ErrorMicroShopUserCreationFailed : Error
        {
            public ErrorMicroShopUserCreationFailed() : base(nameof(MICROSHOP_USER_CREATION_FAILED), 2003)
            {
                Message = "MicroShop user creation failed!";
            }

            public override HttpStatusCode HttpStatusCode => HttpStatusCode.InternalServerError;
        }

        private sealed class ErrorMicroShopUserUserNameDoesNotMatch : Error
        {
            public ErrorMicroShopUserUserNameDoesNotMatch() : base(nameof(MICROSHOP_USER_USERNAME_DOES_NOT_MATCH), 2004)
            {
                Message = "MicroShop user userName does not match!";
            }

            public override HttpStatusCode HttpStatusCode => HttpStatusCode.InternalServerError;
        }
    }
}
