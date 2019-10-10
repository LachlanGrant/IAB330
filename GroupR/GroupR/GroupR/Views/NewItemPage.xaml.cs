﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GroupR.Models;

namespace GroupR.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Review Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Review
            {
                friendliness = 1,
                workEthic = 1,
                workQuality = 1,
                name = "",
                studentNumber = "",
                subject = ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            Item = new Review
            {
                friendliness = 1,
                workEthic = 1,
                workQuality = 1,
                name = "",
                studentNumber = "",
                subject = ""
            };
            await Navigation.PopModalAsync();
        }
    }
}