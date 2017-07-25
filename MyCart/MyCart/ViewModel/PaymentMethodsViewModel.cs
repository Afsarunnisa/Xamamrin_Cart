using System;
using System.Diagnostics;

using MyCart.Models;

namespace MyCart.ViewModel
{
    public class PaymentMethodsViewModel
    {
        public PaymentMethodsViewModel()
        {
			this.CallApis();


		
		}


		private async void CallApis()
        {
			App.RestApiManager.GetPaymentMethods();

			PostPaymentMethods paymentMethod = new PostPaymentMethods()
			{
				comment = "simple comment",
				payment_method = "cod",
				agree = "1"

			};

			Boolean paymentMethodSuc = false;

            paymentMethodSuc = await App.RestApiManager.SetPaymentMethod(paymentMethod);

			if (paymentMethodSuc == true)
			{

				Debug.WriteLine("Call confirm cart");
			}
        }

	}
}
