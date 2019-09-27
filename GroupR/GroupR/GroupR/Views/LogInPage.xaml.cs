using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GroupR.Models;
using GroupR.ViewModels;
using GroupR.Views;

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
    }
}