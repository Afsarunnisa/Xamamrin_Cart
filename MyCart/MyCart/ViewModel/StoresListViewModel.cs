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
    public class StoresListViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Store> stores;
		public ObservableCollection<Store> Stores
		{
			get { return stores; }
			set
			{
				stores = value;
				OnPropertyChanged("Stores");
			}
		}

        public StoresListViewModel()
        {

			Stores = new ObservableCollection<Store>();
			this.GetStores();
        }

        private async void GetStores()
        { 
            try{
                

                List<Store> data = await App.RestApiManager.GetStores();

				foreach (var store in data)
				{
                    Stores.Add(store);					
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
