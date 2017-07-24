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
    public class CategoriesViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }


        public CategoriesViewModel()
        {

            Categories = new ObservableCollection<Category>();

            this.GetCategory();


        }

        private async void GetCategory(){

            try{
                List<Category> data = await App.RestApiManager.GetCategories();

				Debug.WriteLine("data {0}", data);

				foreach (var category in data)
				{
					Debug.WriteLine("product {0}", category.name);
					//Items.Add(new Products() { name =  product.name, image = product.image });
                    Categories.Add(category);
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
