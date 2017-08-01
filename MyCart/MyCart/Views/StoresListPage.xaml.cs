using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

using MyCart.ViewModel;
using MyCart.Models;


namespace MyCart.Views
{
    public partial class StoresListPage : ContentPage
    {
        public StoresListPage()
        {
            InitializeComponent();

            BindingContext = new StoresListViewModel();

		}

        private void OnStoreSelected(object sender, SelectedItemChangedEventArgs e)
        {
			if (e.SelectedItem == null) return; // don't do anything if we just de-selected the row

			var item = (Store)e.SelectedItem;
            Navigation.PushAsync(new AllProductsListPage("0", item.id));

			((ListView)sender).SelectedItem = null; // de-select the row



		}
    }
}
