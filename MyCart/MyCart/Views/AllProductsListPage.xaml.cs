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

            Debug.WriteLine("productID {0}", productID);
            Debug.WriteLine("StoreID {0}", storeID);

			BindingContext = new AllProductsListViewModel(productID, storeID);

        }

        // on product slection  

		private void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
		{

            var item = (Products)e.SelectedItem;
            Debug.WriteLine(@"   item {0}", item.name);

			// Navigation to product details  

			Navigation.PushAsync(new ProductDetailsPage(item));

		}

		// On cart click  

		private void Cart_Clicked(object sender, EventArgs e)
		{
            this.Navigation.PushAsync(new MyCartPage());
		}


    }
}
