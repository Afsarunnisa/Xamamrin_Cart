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



using Xamarin.Forms;

namespace MyCart.ViewModel
{
    public class SwitcherPageViewModel : CarouseBaseViewModel
    {


		private ObservableCollection<Store> storesList;
		public ObservableCollection<Store> StoresList
		{
			get { return storesList; }
			set
			{
				storesList = value;
				OnPropertyChanged("StoresList");
			}
		}

        private ObservableCollection<FeaturedProducts> featuredProductsList;
		public ObservableCollection<FeaturedProducts> FeaturedProductsList
		{
			get { return featuredProductsList; }
			set
			{
				featuredProductsList = value;
				OnPropertyChanged("FeaturedProductsList");
			}
		}



		public SwitcherPageViewModel()
		{

            this.GetOCToken();

			StoresList = new ObservableCollection<Store>();
            FeaturedProductsList = new ObservableCollection<FeaturedProducts>();


			Pages = new List<HomeViewModel>() {
                new HomeViewModel { Title = "", Background = Color.Transparent, ImageSource = "iphone.png" },
				new HomeViewModel { Title = "", Background = Color.Transparent, ImageSource = "macbook.png" },
			};

			CurrentPage = Pages.First();
		}

        private async void GetOCToken(){

			try
			{
                Boolean isTokenRecived = await App.RestApiManager.GetToken();
                if(isTokenRecived == true){
					this.GetStores();
                    this.GetFeatureProducts();
				}
		
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}


		}

        private async void GetFeatureProducts(){
            try{

                List<FeaturedProducts> data = await App.RestApiManager.GetFeaturedProducts();

                foreach (var product in data){
                    FeaturedProductsList.Add(product);
                }


			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
        }


		private async void GetStores()
		{
			try
			{


				List<Store> data = await App.RestApiManager.GetStores();

				foreach (var store in data)
				{
					StoresList.Add(store);
					StoresList.Add(store);
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}

		}


		IEnumerable<HomeViewModel> _pages;
		public IEnumerable<HomeViewModel> Pages
		{
			get
			{
				return _pages;
			}
			set
			{
				SetObservableProperty(ref _pages, value);
				CurrentPage = Pages.FirstOrDefault();
			}
		}

		HomeViewModel _currentPage;
		public HomeViewModel CurrentPage
		{
			get
			{
				return _currentPage;
			}
			set
			{
				SetObservableProperty(ref _currentPage, value);
			}
		}
    }

	//public class HomeViewModel : CarouseBaseViewModel, ITabProvider
	public class HomeViewModel : CarouseBaseViewModel
	{
		public HomeViewModel() { }

		public string Title { get; set; }
		public Color Background { get; set; }
		public string ImageSource { get; set; }
	}
}
