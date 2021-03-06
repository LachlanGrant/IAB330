using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GroupR.Models;
using GroupR.ViewModels;
using GroupR.Views;
using System.Diagnostics;

namespace GroupR.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class SignUpPage : ContentPage
    {
        SignUpViewModel viewModel;

        public SignUpPage(SignUpViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public SignUpPage()
        {
            InitializeComponent();

            viewModel = new SignUpViewModel();
            BindingContext = viewModel;
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());
        }

        private async void Signup_Button_Pressed(object sender, EventArgs e)
        {
            await viewModel.ExecuteSignup();
            Debug.WriteLine(viewModel.signupSuccess.ToString());
            // We can now access viewModel.loginSuccess :)
            if(viewModel.signupSuccess == true)
            {
                //if signup is a success, push to browse review screen
                await DisplayAlert("Successfully created account",
                                   "You can now sign in!", "Continue");
                await Navigation.PushAsync(new LogInPage());
            } else
            {
                await DisplayAlert("Error",
                                   "Unable to create account, please try another username", "Close");
            }
        }
    }
}