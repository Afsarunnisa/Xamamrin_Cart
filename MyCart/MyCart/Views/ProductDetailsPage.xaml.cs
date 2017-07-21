﻿using System;
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

            Debug.WriteLine("product val {0}", product.name);
			Debug.WriteLine("product images  {0}", product.images);

			BindingContext = product;

            currentProduct = product;

        }


		void Add_Cart_Clicked(object sender, EventArgs e)
		{

            AddCart cart = new AddCart();
            cart.product_id = currentProduct.id;
            cart.quantity = "1";

            App.RestApiManager.AddToCart(cart);
            
        
        }



    }
}