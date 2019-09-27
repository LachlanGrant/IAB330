using System;
using System.Windows.Input;
using GroupR.Models;
using Xamarin.Forms;
using GroupR.Services;

namespace GroupR.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        // public User User { get; set; }
        LoginServiceStore registerServices = new LoginServiceStore();

        public string Username { get; set; }
        public string Password { get; set; }

        public string Message { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await registerServices.LoginAsync(Username, Password);

                    if (isSuccess)
                    {
                        Message = "Login succesful";
                    }
                    else
                    {
                        Message = "Login failed";
                    }
                });
            }
        }

    }
}
