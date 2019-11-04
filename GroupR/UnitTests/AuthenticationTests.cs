using NUnit.Framework;
using System;
using GroupR.Models;
using GroupR.Services;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture()]
    public class AuthenticationTests
    {
        [Test()]
        public async Task TestRegisterUserAsync()
        {
            LoginServiceStore registerServices = new LoginServiceStore();

            User user = new User();

            user.Username = "lachlangrant";
            user.Password = "lachlanpassword";

            var result = await registerServices.RegisterAsync(user.Username, user.Password);
            Assert.IsTrue(result);
        }

        [Test()]
        public async Task TestLoginUserAsync()
        {
            LoginServiceStore loginServices = new LoginServiceStore();

            User user = new User();

            user.Username = "lachlangrant";
            user.Password = "qwerty";

            var isSuccess = await loginServices.LoginAsync(user.Username, user.Password);

            Assert.IsTrue(isSuccess.Success);

        }

    }
}
