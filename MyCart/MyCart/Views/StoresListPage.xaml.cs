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
            
            var item = (Store)e.SelectedItem;
            Navigation.PushAsync(new AllProductsListPage("0", item.id));

		}
    }
}
