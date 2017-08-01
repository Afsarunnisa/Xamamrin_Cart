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

				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					var token = App.Current.Properties["AccessToken"] as string;
                    if(token != ""){
						this.GetFeatureProducts();

                    }else{
						Boolean isTokenRecived = await App.RestApiManager.GetToken();
						if (isTokenRecived == true)
						{
							this.GetFeatureProducts();
						}
                    }
                }else{

					Boolean isTokenRecived = await App.RestApiManager.GetToken();
					if (isTokenRecived == true)
					{
						this.GetFeatureProducts();
					}
                }

    //            Boolean isTokenRecived = await App.RestApiManager.GetToken();
    //            if(isTokenRecived == true){
    //                this.GetFeatureProducts();
				//}
		
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

                    Debug.WriteLine("product {0}", product.name);

                    FeaturedProductsList.Add(product);
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
