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
        public CategoriesListPage()
        {
            InitializeComponent();
            BindingContext = new CategoriesViewModel();

		}

		private void OnCategorySelected(object sender, SelectedItemChangedEventArgs e)
		{

            var item = (Category)e.SelectedItem;
			Navigation.PushAsync(new AllProductsListPage(item.category_id, "0"));

		}

	}
}
