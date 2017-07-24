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

        public MyCartViewModel()
        {
			CartItems = new ObservableCollection<CartProducts>();


   //         var page1 = new CartProducts() { name="test", thumb="test", price ="10" };
			//var page2 = new CartProducts() { name = "test", thumb = "test", price = "10" };
			//var page3 = new CartProducts() { name = "test", thumb = "test", price = "10" };
			//var page4 = new CartProducts() { name = "test", thumb = "test", price = "10" };
			//var page5 = new CartProducts() { name = "test", thumb = "test", price = "10" };


			//CartItems.Add(page1);
			//CartItems.Add(page2);
			//CartItems.Add(page3);
			//CartItems.Add(page1);
			//CartItems.Add(page2);
			//CartItems.Add(page3);




			this.GetCart();

			//App.RestApiManager.GetCart();            this.GetProducts();

		}


		private async void GetCart()
		{
			try
			{
				Cart cartData = await App.RestApiManager.GetCart();

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
