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

		void Checkout_Cart_Clicked(object sender, EventArgs e)
        {

         
            var isUserLogin = App.Current.Properties["UserLogin"];

            if(isUserLogin == "true"){
                this.Navigation.PushAsync(new PaymentMethodsPage());

			}else{
				this.Navigation.PushAsync(new GuestCheckOutPage());

			}


		}
	}
}