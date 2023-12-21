using MicroShop.IdentityService.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace MicroShop.IdentityService.Tests.Unit.Tools
{
    public static class UserManagerMocks
    {
        public static Mock<UserManager<TUser>> MockUserManager<TUser>(IList<TUser> ls) where TUser : MicroShopUser
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.FindByNameAsync( It.IsAny<string>())).ReturnsAsync(It.IsAny<TUser>()).Callback<string>(( y) => ls.FirstOrDefault(x=>x.UserName == y));
            return mgr;
        }
    }
}
