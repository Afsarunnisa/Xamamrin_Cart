using System;
using System.Collections.Generic;

using Xamarin.Forms;

using MyCart.ViewModel;
using MyCart.Models;

using System.Diagnostics;



namespace MyCart.Views
{
    public partial class AllProductsListPage : ContentPage
    {
        public AllProductsListPage(string productID, string storeID)
        {
            InitializeComponent();
			BindingContext = new AllProductsListViewModel(productID, storeID);


			ProductsListView.SelectedItem = null;

		}

        // on product slection  

		private void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
        {
			if (e.SelectedItem == null) return; // don't do anything if we just de-selected the row



			var item = (Products)e.SelectedItem;

			// Navigation to product details  
			Navigation.PushAsync(new ProductDetailsPage(item));

			((ListView)sender).SelectedItem = null; // de-select the row



		}

		// On cart click  

		private void Cart_Clicked(object sender, EventArgs e)
		{
            this.Navigation.PushAsync(new MyCartPage());
		}

		private void Wish_Cart_Clicked(object sender, EventArgs e)
		{

			//var item = (Products)e.SelectedItem;

			Debug.WriteLine("selected product ");


			//var item = (Xamarin.Forms.Button)sender;
        //    Products listitem = (from itm in Products
							 //where itm.name == item.CommandParameter.ToString()
							 //select
                    //itm).FirstOrDefault<Products>();



			//allItems.Remove(listitem);
		}



    }
}
