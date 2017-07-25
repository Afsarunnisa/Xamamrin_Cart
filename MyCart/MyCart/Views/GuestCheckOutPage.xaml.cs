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

   //         GuestUser user = new GuestUser()
   //         {
   //             firstname = FirstName.Text,
   //             lastname = LastName.Text,
   //             email = Email.Text,
   //             telephone = Telephone.Text,
   //             address_1 = Address.Text,
   //             city = City.Text,
   //             postcode = PostCode.Text,
   //             country_id = "99",
   //             zone_id = "4231"
   //         };



			//Debug.WriteLine("firstname {0}", user.firstname);
			//Debug.WriteLine("lastname {0}", user.lastname);
			//Debug.WriteLine("email {0}", user.email);
			//Debug.WriteLine("telephone {0}", user.telephone);


			//nextBtn.CommandParameter = user;

        }


        private void Login_Clicked(object sender, EventArgs e)
		{
            this.Navigation.PushAsync(new LoginPage());
		}
    }
}
