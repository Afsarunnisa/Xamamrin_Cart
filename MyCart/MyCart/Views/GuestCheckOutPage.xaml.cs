using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

using MyCart.Models;
using MyCart.ViewModel;

namespace MyCart.Views
{
    public partial class GuestCheckOutPage : ContentPage
    {
        public GuestCheckOutPage()
        {
            InitializeComponent();

            BindingContext = new GuestCheckOutViewModel(this.Navigation);

        }


        private void Login_Clicked(object sender, EventArgs e)
		{
            this.Navigation.PushAsync(new LoginPage());
		}
    }
}
