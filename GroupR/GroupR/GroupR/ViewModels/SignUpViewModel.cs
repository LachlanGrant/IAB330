using System;
using System.Windows.Input;
using GroupR.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GroupR.Services;
using GroupR.Views;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GroupR.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        // public User User { get; set; }
        LoginServiceStore registerServices = new LoginServiceStore();

        public string Username { get; set; }
        public string Password { get; set; }

        public bool signupSuccess { get; set; }

        public async Task ExecuteSignup()
        {
            try
            {
                var isSuccess = await registerServices.RegisterAsync(Username, Password);
                Debug.WriteLine(isSuccess.ToString());
                this.signupSuccess = isSuccess;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

    }
}
