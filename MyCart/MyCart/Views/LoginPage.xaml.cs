using System;
using System.Collections.Generic;

using Xamarin.Forms;

using MyCart.ViewModel;

namespace MyCart.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
			BindingContext = new LoginViewModel(this.Navigation);

		}
    }
}
