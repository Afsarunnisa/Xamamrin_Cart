using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLabs.Forms.Mvvm;


using MyCart.Controls;
using MyCart.ViewModel;
using MyCart.Models;

namespace MyCart.Views
{
    public partial class DashboardPage : ContentPage
    {

		//View _tabs;
		RelativeLayout relativeLayout;
		CarouselLayout.IndicatorStyleEnum _indicatorStyle;
		SwitcherPageViewModel viewModel;

        Grid innerGrid;
        Image image;

        public DashboardPage()
        {
			_indicatorStyle = CarouselLayout.IndicatorStyleEnum.Dots;

			viewModel = new SwitcherPageViewModel();
			BindingContext = viewModel;

            Title = "Dashboard";

			relativeLayout = new RelativeLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var pagesCarousel = CreatePagesCarousel();
			var dots = CreatePagerIndicatorContainer();

            pagesCarousel.BackgroundColor = Color.White;


			switch (pagesCarousel.IndicatorStyle)
			{
				case CarouselLayout.IndicatorStyleEnum.Dots:
					relativeLayout.Children.Add(pagesCarousel,
						Constraint.RelativeToParent((parent) =>
						{
							return parent.X;
						}),
						Constraint.RelativeToParent((parent) =>
						{
							return parent.Y;
						}),
						Constraint.RelativeToParent((parent) =>
						{
							return parent.Width;
						}),
						Constraint.RelativeToParent((parent) =>
						{
							return 180;
						})
					);

					relativeLayout.Children.Add(dots,
						Constraint.Constant(0),
						Constraint.RelativeToView(pagesCarousel,
							(parent, sibling) =>
							{
								return sibling.Height - 18;
							}),
						Constraint.RelativeToParent(parent => parent.Width),
						Constraint.Constant(18)
					);
					break;

					// OTHER PAGEINDOCATORS LEFT OUT FOR CLARITY’S SAKE
			}


        

			var FeaturesLabel = new Label { FontAttributes = FontAttributes.Bold };
            FeaturesLabel.Text = "Featured Products";
			FeaturesLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
			FeaturesLabel.VerticalOptions = LayoutOptions.CenterAndExpand;

			relativeLayout.Children.Add(FeaturesLabel,
                        Constraint.RelativeToParent((parent) =>
						{
							return parent.X;
						}),
                        Constraint.RelativeToView(pagesCarousel,
							(parent, sibling) =>
							{
								return 180 ;
							}),
						Constraint.RelativeToParent(parent => parent.Width),
						Constraint.Constant(36)
					);

			var featuredListDataTemplate = new DataTemplate(() =>
			{
                var contentView = new FeaturedProductViewTemplate();
                return new ViewCell { View = contentView };
			});

            var featuredListView = new ListView { ItemTemplate = featuredListDataTemplate, RowHeight = 100  };
			featuredListView.ItemsSource = viewModel.FeaturedProductsList;
			featuredListView.SeparatorColor = Color.Transparent;
            featuredListView.BackgroundColor = Color.FromHex("#cccccc");

			featuredListView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
			{

				if (e.SelectedItem == null) return; // don't do anything if we just de-selected the row



				var item = (FeaturedProducts)e.SelectedItem;
                Products aproduct = new Products();
                aproduct.name = item.name;
                aproduct.id = item.product_id;
                aproduct.price = item.price;
                aproduct.description = item.description;
                aproduct.image = item.thumb;
                aproduct.price_formated = item.price_formated;


				Navigation.PushAsync(new ProductDetailsPage(aproduct));

				((ListView)sender).SelectedItem = null; // de-select the row


			};

			relativeLayout.Children.Add(featuredListView,
                        Constraint.RelativeToParent((parent) =>
						{
                          return parent.X;
						}),

                            Constraint.RelativeToView(pagesCarousel,
							(parent, sibling) =>
							{
								return sibling.Height + 36;
							}),

                        Constraint.RelativeToParent(parent => (parent.Width) ),
						Constraint.RelativeToParent((parent) =>
						{
                            return parent.Height;
						})
					);


			//ScrollView scroll = new ScrollView
			//{
			//	Content = relativeLayout
			//};


            Grid grid = new Grid();
			grid.Children.Add(relativeLayout);

			innerGrid = new Grid();
            innerGrid.BackgroundColor = Color.White;

            image = new Image();
            image.HorizontalOptions = LayoutOptions.Center;
            image.VerticalOptions = LayoutOptions.Center;
            image.Source = "logo.png";
            image.TranslationY = 0;

			innerGrid.Children.Add(image);

			grid.Children.Add(innerGrid);

			ScrollView scroll = new ScrollView
			{
				Content = grid
			};

   //         NavigationPage.SetHasNavigationBar(this, false);
			//Content = grid;


			string isSplash = "";

			if (App.Current.Properties.ContainsKey("IsSplash"))
			{
				isSplash = App.Current.Properties["IsSplash"] as string;
			}

            if(isSplash == "false"){
				NavigationPage.SetHasNavigationBar(this, false);
				Content = grid;
				App.Current.Properties["IsSplash"] = "true";
            }else{
                Content = relativeLayout;

			}


            //Content = relativeLayout;
        }

        protected override async void OnAppearing(){
			base.OnAppearing();



			

			// Waiting some time
			//await Task.Delay(2000);

			Task.Run(
			   async () =>
			   {
				   this.IsBusy = true;
				   await Task.Delay(2000);
				   Device.BeginInvokeOnMainThread(() => this.Load());
				   this.IsBusy = false;
			   });


			// Start animation
			await Task.WhenAll(
				innerGrid.FadeTo(0, 2000),
				image.ScaleTo(10, 2000)
            );


		}

        void Load(){
            NavigationPage.SetHasNavigationBar(this, true);

		}




		CarouselLayout CreatePagesCarousel()
		{
			var carousel = new CarouselLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				IndicatorStyle = _indicatorStyle,
				ItemTemplate = new DataTemplate(typeof(HomeView))
			};
			carousel.SetBinding(CarouselLayout.ItemsSourceProperty, "Pages");
			carousel.SetBinding(CarouselLayout.SelectedItemProperty, "CurrentPage", BindingMode.TwoWay);

			return carousel;
		}

        CarouselLayout CreateListViewCarousel(){


			var storesDataTemplate = new DataTemplate(() =>
						{

							var grid = new Grid();
							grid.HorizontalOptions = LayoutOptions.FillAndExpand;

							var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
							nameLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
							nameLabel.VerticalOptions = LayoutOptions.CenterAndExpand;
							nameLabel.SetBinding(Label.TextProperty, "name");

							grid.Children.Add(nameLabel);
							return new ViewCell { View = grid };
						});


			var carousel = new CarouselLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
                IndicatorStyle = CarouselLayout.IndicatorStyleEnum.None,
				ItemTemplate = storesDataTemplate
			};

			carousel.SetBinding(CarouselLayout.ItemsSourceProperty, "StoresList");
			carousel.SetBinding(CarouselLayout.SelectedItemProperty, "CurrentPage", BindingMode.TwoWay);

			return carousel;


        }



		View CreatePagerIndicatorContainer()
		{
			return new StackLayout
			{
				Children = { CreatePagerIndicators() }
			};
		}

		View CreatePagerIndicators()
		{
			var pagerIndicator = new PagerIndicatorDots() { DotSize = 5, DotColor = Color.Black };
			pagerIndicator.SetBinding(PagerIndicatorDots.ItemsSourceProperty, "Pages");
			pagerIndicator.SetBinding(PagerIndicatorDots.SelectedItemProperty, "CurrentPage");
			return pagerIndicator;
		}

    }

}
