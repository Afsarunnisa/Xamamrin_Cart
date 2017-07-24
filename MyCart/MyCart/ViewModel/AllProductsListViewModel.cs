using System;
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


        public AllProductsListViewModel()
        {
            Products = new ObservableCollection<Products>();

			this.GetProducts();

			//App.RestApiManager.GetProducts();
        }


		private async void GetProducts()
		{
			try
			{
                List<Products> data = await App.RestApiManager.GetProducts();

				Debug.WriteLine("data {0}", data);

                foreach (var product in data)
				{
					Debug.WriteLine("product {0}", product.name);
					//Items.Add(new Products() { name =  product.name, image = product.image });
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
