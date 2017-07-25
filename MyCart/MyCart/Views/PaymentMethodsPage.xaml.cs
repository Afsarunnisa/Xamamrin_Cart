using System;
using System.Collections.Generic;

using Xamarin.Forms;

using MyCart.ViewModel;

namespace MyCart.Views
{
    public partial class PaymentMethodsPage : ContentPage
    {
        public PaymentMethodsPage()
        {
            InitializeComponent();
            BindingContext = new PaymentMethodsViewModel();

        }
    }
}
