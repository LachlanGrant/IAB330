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
        public void TestRegisterToJSON()
        {
            User user = new User();

            user.Username = "lachlangrant";
            user.Password = "lachlanpassword";

            string expectedJSON = "{\"username\":\"lachlangrant\",\"password\": \"lachlanpassword\"}";

            Assert.AreEqual(LoginServiceStore.UserToJSON(user), expectedJSON);
        }

        [Test()]
        public void TestLoginToJSON()
        {
            User user = new User();

            user.Username = "lachlangrant";
            user.Password = "qwerty";

            String expectedJSON = "{\"username\":\"lachlangrant\",\"password\": \"qwerty\"}";

            Assert.AreEqual(LoginServiceStore.UserToJSON(user), expectedJSON);
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

        [Test()]
        public void TestJSONtoUserLogin()
        {
            String sampleJSON = "{\"success\": true, \"userToken\": " +
                "\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjVkOGMxMjZmYzA5Zjk5MDAzMTY0M2NmMCIsImlhdCI6MTU3Mjc2ODQ1OH0.c5oaNNs93Tzk59oAHXrZovC0ymyBFC0LQvilLz7kf7s\", " +
                "\"user\": { \"_id\": \"5d8c126fc09f990031643cf0\", \"username\": \"lachlangrant\", \"__v\": 0 } }";
            String sampleToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjVkOGMxMjZmYzA5Zjk5MDAzMTY0M2NmMCIsImlhdCI6MTU3Mjc2ODQ1OH0.c5oaNNs93Tzk59oAHXrZovC0ymyBFC0LQvilLz7kf7s";

            UserResponse processedResponse = LoginServiceStore.JSONtoUser(sampleJSON);

            Assert.IsTrue(processedResponse.success);
            Assert.AreEqual(sampleToken, processedResponse.userToken);
        }

        [Test()]
        public void TestJSONtoRegister()
        {
            String sampleJSON = "{ \"success\": true, \"user\": { \"_id\": \"5dbff4692cee8a001f23863f\", " +
                "\"username\": \"lachlangrant3\", \"password\": \"$2a$10$9bonkzcykVHnTL2duT.wMuwVes8uvvj.61ndSTFE4Jr/8erOQkEHi\", \"__v\": 0 } }";

            RegisterResponse processedResponse = LoginServiceStore.JSONtoUser(sampleJSON);

            Assert.IsTrue(processedResponse.success);
        }
    }
}
