﻿using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


using Xamarin.Forms;

using MyCart.Models;
using MyCart.Views;


namespace MyCart.ViewModel
{
    public class GuestCheckOutViewModel : BaseViewModel
    {

		private INavigation _navigation;


		//public GuestUser GuestUserResult { get; private set; }
		//public ICommand NextBtnCommand { get; private set; }

		public GuestCheckOutViewModel(INavigation navitation)
        {
			_navigation = navitation;

			// NextBtnCommand = new Command<GuestUser> (GuestCheckOutNext);
			GuestUserObject = new GuestUser();

		}

  //      void GuestCheckOutNext(GuestUser guestUser){


		//	OnPropertyChanged("GuestUserResult");

		//}

		//public event PropertyChangedEventHandler PropertyChanged;
		//void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
			//PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


         #region Properties         private GuestUser guestUserObject;         /// <summary>         /// Gets or sets the employee object.         /// </summary>         /// <value>The employee object.</value>         public GuestUser GuestUserObject         {             get              { return guestUserObject;              }             set {                 guestUserObject = value; OnPropertyChanged();             }         }        #endregion  

        #region DelegateCommand         Command NextBtnCommandCommand;         /// <summary>         /// Gets the save command.         /// </summary>         /// <value>The save command.</value>        public Command NextBtnCommand 	     { 	          get 	            { 	              return NextBtnCommandCommand ?? (NextBtnCommandCommand = new Command(async () => await ExecuteOnNextClick())); 	            } 	      }
		#endregion


		#region Methods  
		private async Task ExecuteOnNextClick()
		{
            var guestUser = GuestUserObject;
            guestUser.country_id = "99";
            guestUser.zone_id = "4231";

            Boolean value = await App.RestApiManager.AddGuestUser(guestUser);
            Boolean shippingValue = false;

            if(value == true){
               shippingValue = await App.RestApiManager.AddGuestShipping(guestUser);
            }

            if(shippingValue == true){
                Debug.WriteLine("get payment methods");

				//this.Navigation.PushAsync(new MyCartPage());

				Debug.WriteLine("_navigation");
				Debug.WriteLine(_navigation);

                await _navigation.PushAsync(new PaymentMethodsPage());


				//await App.RestApiManager.GetPaymentMethods();

				//PostPaymentMethods paymentMethod = new PostPaymentMethods()
				//{
				//    comment = "simple comment",
				//    payment_method = "cod",
				//    agree = "1"

				//};

				//var paymentMethodSuc = await App.RestApiManager.SetPaymentMethod(paymentMethod);
			}



		}

		#endregion

	}
}