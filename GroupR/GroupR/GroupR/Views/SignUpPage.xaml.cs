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
        }
    }
}