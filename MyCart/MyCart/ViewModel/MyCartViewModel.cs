using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

using MyCart.Data;
using MyCart.Models;


namespace MyCart.ViewModel
{
    public class MyCartViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<CartProducts> cartItems;
		public ObservableCollection<CartProducts> CartItems
		{
			get { return cartItems; }
			set
			{
				cartItems = value;
				OnPropertyChanged("CartItems");
			}
		}

        private string totalItems;
		public string TotalItems
		{
			get { return totalItems; }
			set
			{
				totalItems = value;
				OnPropertyChanged("TotalItems");
			}
		}

		//private string totalPrice;
		//public string TotalPrice
		//{
		//	get { return totalPrice; }
		//	set
		//	{
		//		totalPrice = value;
		//		OnPropertyChanged("TotalPrice");
		//	}
		//}



        public MyCartViewModel()
        {
			CartItems = new ObservableCollection<CartProducts>();
            TotalItems = "";
            //TotalPrice = "";


			this.GetCart();

			
		}


		private async void GetCart()
		{
			try
			{
				Cart cartData = await App.RestApiManager.GetCart();

                TotalItems = cartData.data.total;
                //TotalPrice = cartData.data.total_price

                foreach (var product in cartData.data.products)
				{
					CartItems.Add(product);
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}

		}


		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	}
}