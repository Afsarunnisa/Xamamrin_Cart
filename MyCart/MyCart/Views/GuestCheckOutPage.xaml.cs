using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyCart.Views
{
    public partial class GuestCheckOutPage : ContentPage
    {
        public GuestCheckOutPage()
        {
            InitializeComponent();
        }

		private void Login_Clicked(object sender, EventArgs e)
		{
            this.Navigation.PushAsync(new LoginPage());
		}
    }
}
