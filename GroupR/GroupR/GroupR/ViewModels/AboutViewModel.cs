using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GroupR.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://iab330.rbvea.co")));
        }

        public ICommand OpenWebCommand { get; }
    }
}