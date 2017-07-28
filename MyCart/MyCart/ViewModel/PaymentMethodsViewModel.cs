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

			if (isUserLogin == "true")
			{
                this.postPayment();
			}

			this.GetShippingMethods();
            this.GetPaymentMethods();


			//this.CallApis();
		}

        private async void postPayment(){

            try{

                Dictionary<string, string> postpaymentDict = new Dictionary<string, string>();

                postpaymentDict.Add("address_1","Kossuth Lajos út 88");
				postpaymentDict.Add("address_2", "test");
				postpaymentDict.Add("city", "Budapest");

				postpaymentDict.Add("company_id", "company");
				postpaymentDict.Add("company", "company");
				postpaymentDict.Add("country_id", "97");



            }
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
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



				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
        }

        private async void GetPaymentMethods(){

            try{
                
            }
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
        }



		private async void CallApis()
        {
			await App.RestApiManager.GetPaymentMethods();

			PostPaymentMethods paymentMethod = new PostPaymentMethods()
			{
				comment = "simple comment",
				payment_method = "cod",
				agree = "1"

			};

            Boolean paymentMethodSuc = await App.RestApiManager.SetPaymentMethod(paymentMethod);

			if (paymentMethodSuc == true)
			{
				Debug.WriteLine("Call confirm cart");



			}
        }


		private async Task ExecuteOnCheckOutClick()
        {

			Debug.WriteLine("Call confirm cart button");

			await App.RestApiManager.ConfirmCart();


		}

	}
}
