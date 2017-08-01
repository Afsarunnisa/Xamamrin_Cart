using System;
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

namespace MyCart.ViewModel
{
    public class PaymentMethodsViewModel : BaseViewModel
    {

		#region DelegateCommand
		Command CheckOutBtnCommandCommand;
		/// <summary>
		/// Gets the save command.
		/// </summary>
		/// <value>The save command.</value>
		public Command CheckOutBtnCommand
		{
			get
			{
				return CheckOutBtnCommandCommand ?? (CheckOutBtnCommandCommand = new Command(async () => await ExecuteOnCheckOutClick()));
			}
		}
		#endregion




		private ObservableCollection<ShippingQuoteValues> shippingValues;
		public ObservableCollection<ShippingQuoteValues> ShippingValues
		{
			get { return shippingValues; }
			set
			{
				shippingValues = value;
				OnPropertyChanged("ShippingValues");
			}
		}

		private ObservableCollection<PaymentMethodsValues> paymentValues;
		public ObservableCollection<PaymentMethodsValues> PaymentValues
		{
			get { return paymentValues; }
			set
			{
				paymentValues = value;
				OnPropertyChanged("PaymentValues");
			}
		}


		public PaymentMethodsViewModel()
        {

			ShippingValues = new ObservableCollection<ShippingQuoteValues>();


			var isUserLogin = App.Current.Properties["UserLogin"];

			
			this.GetShippingMethods();
            this.GetPaymentMethods();


			//this.CallApis();
		}

    
		

		private async void GetShippingMethods()
        {

			try
			{

				Dictionary<string, ShippingMethodsValues> shippingMethiods = await App.RestApiManager.GetShippingMethods();

				var arrayOfAllKeys = shippingMethiods.Keys.ToArray();

				foreach (var shipping in arrayOfAllKeys)
				{
					ShippingMethodsValues val = shippingMethiods[shipping];
                    Dictionary<string, ShippingQuoteValues> quote = val.quote;

                    ShippingQuoteValues shippingMethodValues = quote[shipping];
					ShippingValues.Add(shippingMethodValues);

                    this.PostShippingMethods();
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
        }

        private async void GetPaymentMethods(){

            try{
			 var paymentResponse = await App.RestApiManager.GetPaymentMethods();

                Debug.WriteLine("paymentResponse {0}", paymentResponse);

                this.PostPaymentMethods();

			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
        }



        private async void PostPaymentMethods()
        {
			//await App.RestApiManager.GetPaymentMethods();

			PostPaymentMethods paymentMethod = new PostPaymentMethods()
			{
				comment = "simple comment",
				payment_method = "cod",
				agree = "1"

			};

            Boolean paymentMethodSuc = await App.RestApiManager.SetPaymentMethod(paymentMethod);

			if (paymentMethodSuc == true)
			{
				Debug.WriteLine("Call confirm cart Payment method success");

			}
        }


        private async void PostShippingMethods()

		{
			//await App.RestApiManager.GetPaymentMethods();

            PostShippingMethods shippingMethod = new PostShippingMethods()
			{
				comment = "simple comment",
				shipping_method = "flat.flat"
			};

            Boolean ShippingMethodSuc = await App.RestApiManager.SetShippingMethod(shippingMethod);

			if (ShippingMethodSuc == true)
			{
				Debug.WriteLine("Call confirm cart shipping method success");

			}
		}



		private async Task ExecuteOnCheckOutClick()
        {

			Debug.WriteLine("Call confirm cart button");

			var order =await App.RestApiManager.ConfirmCart();

            Debug.WriteLine("Order ID {0}", order.data.order_id);


			if(order.data.order_id != ""){
                var OrerID =  await App.RestApiManager.ConfirmPutCart();
                var orderstatus = "Order Placed Successfuly... Here is your Order id " + OrerID;

				DisplayAlert("Order", orderstatus);

            }
		}


		public void DisplayAlert(string title, string message)
		{
			string[] values = { title, message };
            MessagingCenter.Send<PaymentMethodsViewModel, string[]>(this, "DisplayAlert", values);
		}


	}
}
