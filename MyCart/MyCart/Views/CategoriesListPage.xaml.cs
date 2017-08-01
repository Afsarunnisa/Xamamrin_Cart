using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

using MyCart.ViewModel;
using MyCart.Models;


namespace MyCart.Views
{
    public partial class CategoriesListPage : ContentPage
    {

        CategoriesViewModel vm;

        public CategoriesListPage()
        {
            InitializeComponent();

            vm = new CategoriesViewModel();
            BindingContext = vm;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

			//if (vm.Categories.Count == 0)
			//{
   //             await this.DisplayAlert("Categories", "No Categories found", "Ok");
			//}
        }



		private void OnCategorySelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) return; // don't do anything if we just de-selected the row

			var item = (Category)e.SelectedItem;
			Navigation.PushAsync(new AllProductsListPage(item.category_id, "0"));
			((ListView)sender).SelectedItem = null; // de-select the row


		}

	}
}
