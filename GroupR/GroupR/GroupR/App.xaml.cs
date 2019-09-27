using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GroupR.Services;
using GroupR.Views;

using Xamarin.Essentials;

namespace GroupR
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ReviewDataStore>();

            if (Preferences.Get("has_token", false)) //appsettings,getvaluedeafult
            {
                MainPage = new MainPage();
            } else
            {
                // Login Page
                MainPage = new NavigationPage(new SignUpPage());
            }
            
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
