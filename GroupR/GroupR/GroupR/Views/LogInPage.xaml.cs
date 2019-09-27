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
    public partial class LogInPage : ContentPage
    {
        LogInViewModel viewModel;

        public LogInPage(LogInViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public LogInPage()
        {
            InitializeComponent();

            viewModel = new LogInViewModel();
            BindingContext = viewModel;
        }

        private async void Login_Button_Pressed(object sender, EventArgs e)
        {
            await viewModel.ExecuteLogin();
            Debug.WriteLine(viewModel.loginSuccess.ToString());
            // We can now access viewModel.loginSuccess :)
        }
    }
}