using System;
using System.Collections.Generic;

using Xamarin.Forms;

using MyCart.Models;

using System.Diagnostics;


namespace MyCart.Views
{
    public partial class ProductDetailsPage : ContentPage
    {
        Products currentProduct;


        public ProductDetailsPage(Products product)
        {
            InitializeComponent();
     		BindingContext = product;
            currentProduct = product;

        }


		async void Add_Cart_Clicked(object sender, EventArgs e)
		{

            AddCart cart = new AddCart();
            cart.product_id = currentProduct.id;
            cart.quantity = "1";


            //App.RestApiManager.AddToCart(cart);

            Boolean isProductAdded = await App.RestApiManager.AddToCart(cart);

            if(isProductAdded == true){
                await this.DisplayAlert("Product", "Product Added", "Ok");
            }

		}

    }
}
