using System;
using System.Collections.Generic;

using Xamarin.Forms;

using MyCart.ViewModel;

namespace MyCart.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
			BindingContext = new SignUpViewModel(this.Navigation);

		}
    }
}
