using System;
using System.Collections.Generic;

using Xamarin.Forms;

using MyCart.ViewModel;


namespace MyCart.Views
{
    public partial class MyCartPage : ContentPage
    {
        public MyCartPage()
        {
            InitializeComponent();

            BindingContext = new MyCartViewModel();

        }
    }
}
