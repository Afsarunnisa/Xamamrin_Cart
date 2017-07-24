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

			var page1 = new MenuItemModel() { Title = "Home", Icon = "", TargetType = typeof(DashboardPage) };
			var page2 = new MenuItemModel() { Title = "All Products", Icon = "", TargetType = typeof(AllProductsListPage) };
			var page3 = new MenuItemModel() { Title = "Featured Products", Icon = "", TargetType = typeof(DashboardPage) };
			var page4 = new MenuItemModel() { Title = "Categories", Icon = "", TargetType = typeof(CategoriesListPage) };
			var page5 = new MenuItemModel() { Title = "WishList", Icon = "", TargetType = typeof(WishListPage) };
			var page6 = new MenuItemModel() { Title = "Contact us", Icon = "", TargetType = typeof(DashboardPage) };
			var page7 = new MenuItemModel() { Title = "Login", Icon = "", TargetType = typeof(DashboardPage) };

			menuList.Add(page1);
			menuList.Add(page2);
			menuList.Add(page3);
			menuList.Add(page4);
			menuList.Add(page5);
			menuList.Add(page6);
			menuList.Add(page7);

			menuListView.ItemsSource = menuList;


			Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(DashboardPage)));

            App.RestApiManager.GetToken();
		}

		private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
		{

			var item = (MenuItemModel)e.SelectedItem;
			Type page = item.TargetType;

            Debug.WriteLine("page {0}", page);

            if(item.Title == "All Products"){
				Page displayPage = (Page)Activator.CreateInstance(page, "0");
				Detail = new NavigationPage(displayPage);
            }else{
				Detail = new NavigationPage((Page)Activator.CreateInstance(page));
			}

 

			IsPresented = false;
		}

	}
}
