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

			Debug.WriteLine(@"   Store test");

            var item = (Store)e.SelectedItem;

			Debug.WriteLine(@"   store {0}", item.name);
			Debug.WriteLine(@"   store id {0}", item.id);

            Navigation.PushAsync(new AllProductsListPage("0", item.id));


		}
    }
}
