using System;
using System.Collections.Generic;

using Xamarin.Forms;

using MyCart.ViewModel;

namespace MyCart.Views
{
    public partial class CategoriesListPage : ContentPage
    {
        public CategoriesListPage()
        {
            InitializeComponent();
			BindingContext = new AllProductsListViewModel();

		}
    }
}
