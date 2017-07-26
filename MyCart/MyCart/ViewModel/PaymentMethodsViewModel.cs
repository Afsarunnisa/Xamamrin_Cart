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




		public PaymentMethodsViewModel()
        {
			this.CallApis();
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
