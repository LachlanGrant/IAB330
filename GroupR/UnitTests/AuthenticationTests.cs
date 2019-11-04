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
        public void TestRegisterUser()
        {
            LoginServiceStore registerServices = new LoginServiceStore(); 

            User user = new User();

            user.Username = "lachlangrant";
            user.Password = "lachlanpassword";

            Assert.IsTrue(registerServices.RegisterAysnc(user.Username, user.Password));
        }

        [Test()]
        public void TestLoginUser()
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
