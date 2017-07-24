﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

using MyCart.ViewModel;
using MyCart.Models;

using System.Diagnostics;



namespace MyCart.Views
{
    public partial class AllProductsListPage : ContentPage
    {
        public AllProductsListPage(string productID)
        {
            InitializeComponent();

            Debug.WriteLine("productID {0}", productID);

            BindingContext = new AllProductsListViewModel(productID);



        }


		private void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
		{

            var item = (Products)e.SelectedItem;

            Debug.WriteLine(@"   item {0}", item.name);


            Navigation.PushAsync(new ProductDetailsPage(item));

		}

		private void Cart_Clicked(object sender, EventArgs e)
		{
            this.Navigation.PushAsync(new MyCartPage());
		}



    }
}
