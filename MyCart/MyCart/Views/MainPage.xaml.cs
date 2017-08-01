using System;
using System.Collections.Generic;

using Xamarin.Forms;

using MyCart.Models;
using MyCart.Views;
using MyCart.Data;

using System.Diagnostics;


namespace MyCart.Views
{
    public partial class MainPage : MasterDetailPage
    {

		public List<MenuItemModel> menuList { get; set; }

		public MainPage()
        {
            InitializeComponent();
       
			menuList = new List<MenuItemModel>();

			var page1 = new MenuItemModel() { Title = "Home", Icon = "Home", TargetType = typeof(DashboardPage) };
            var page2 = new MenuItemModel() { Title = "Stores", Icon = "Store", TargetType = typeof(StoresListPage) };
			var page3 = new MenuItemModel() { Title = "All Products", Icon = "Products", TargetType = typeof(AllProductsListPage) };
			//var page4 = new MenuItemModel() { Title = "Featured Products", Icon = "", TargetType = typeof(DashboardPage) };
			var page5 = new MenuItemModel() { Title = "Categories", Icon = "Categories", TargetType = typeof(CategoriesListPage) };
			var page6 = new MenuItemModel() { Title = "WishList", Icon = "WishList", TargetType = typeof(WishListPage) };
			var page7 = new MenuItemModel() { Title = "Contact us", Icon = "Contact", TargetType = typeof(DashboardPage) };
            var page8 = new MenuItemModel() { Title = "Login", Icon = "Login", TargetType = typeof(LoginPage) };

			menuList.Add(page1);
			menuList.Add(page2);
			menuList.Add(page3);
			//menuList.Add(page4);
			menuList.Add(page5);
			menuList.Add(page6);
			//menuList.Add(page7);
			menuList.Add(page8);

			menuListView.ItemsSource = menuList;


            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(DashboardPage))){
                BarBackgroundColor = Color.FromHex("#06A2CB"),
                BarTextColor = Color.White,
            };


		}

		private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
		{

			if (e.SelectedItem == null) return; // don't do anything if we just de-selected the row

			var item = (MenuItemModel)e.SelectedItem;
			Type page = item.TargetType;


            if(item.Title == "All Products"){
				Page displayPage = (Page)Activator.CreateInstance(page, "0", "0");
				Detail = new NavigationPage(displayPage)
				{
					BarBackgroundColor = Color.FromHex("#06A2CB"),
					BarTextColor = Color.White,
				};
            }else{
				Detail = new NavigationPage((Page)Activator.CreateInstance(page))
				{
					BarBackgroundColor = Color.FromHex("#06A2CB"),
					BarTextColor = Color.White,
				};
			}

			IsPresented = false;

			//((ListView)sender).SelectedItem = null;

			((ListView)sender).SelectedItem = null; // de-select the row

		}
	}
}
