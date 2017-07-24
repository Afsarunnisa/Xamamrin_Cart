﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

using MyCart.Data;
using MyCart.Models;

namespace MyCart.ViewModel
{
    public class AllProductsListViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Products> products;
		public ObservableCollection<Products> Products
		{
			get { return products; }
			set
			{
				products = value;
				OnPropertyChanged("Products");
			}
		}


        public AllProductsListViewModel(string productID)
        {

            Debug.WriteLine("productID {0}", productID);

			Products = new ObservableCollection<Products>();

            this.GetProducts(productID);

			//App.RestApiManager.GetProducts();
        }


		private async void GetProducts(string productID)
		{
			try
			{

                Debug.WriteLine("productID in viewmodel {0}", productID);

                List<Products> data = await App.RestApiManager.GetProducts(productID);

				Debug.WriteLine("data {0}", data);

                foreach (var product in data)
				{
					Products.Add(product);
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}

		}

		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


	}
}
