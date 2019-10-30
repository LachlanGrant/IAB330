using System;
using System.Windows.Input;
using GroupR.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using GroupR.Services;
using System.Diagnostics;
using GroupR.Views;

namespace GroupR.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        // public User User { get; set; }
        LoginServiceStore registerServices = new LoginServiceStore();

        public string Username { get; set; }
        public string Password { get; set; }

        public bool loginSuccess { get; set; }

        public async Task ExecuteLogin()
        {
            try
            {
                var isSuccess = await registerServices.LoginAsync(Username, Password);
                Debug.WriteLine(isSuccess.ToString());

                this.loginSuccess = isSuccess.Success;

                //save token
                Preferences.Set("auth_token", isSuccess.userToken);
                Preferences.Set("username", Username);
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
