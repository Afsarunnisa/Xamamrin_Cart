using System;
using System.Collections.Generic;

using Xamarin.Forms;

using MyCart.Controls;
using MyCart.ViewModel;

namespace MyCart.Views
{
    public partial class DashboardPage : ContentPage
    {

		View _tabs;
		RelativeLayout relativeLayout;
		CarouselLayout.IndicatorStyleEnum _indicatorStyle;
		SwitcherPageViewModel viewModel;

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

            pagesCarousel.BackgroundColor = Color.Bisque;

            //var listCarousel = CreateListViewCarousel();


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
							return parent.Height / 3;
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


        

			var storesLabel = new Label { FontAttributes = FontAttributes.Bold };
            storesLabel.Text = "STORES";
			storesLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
			storesLabel.VerticalOptions = LayoutOptions.CenterAndExpand;
            storesLabel.BackgroundColor = Color.Aqua;

			relativeLayout.Children.Add(storesLabel,
                        Constraint.RelativeToParent((parent) =>
						{
							return parent.X;
						}),
                        Constraint.RelativeToView(pagesCarousel,
							(parent, sibling) =>
							{
								return sibling.Height;
							}),
						Constraint.RelativeToParent(parent => parent.Width),
						Constraint.Constant(36)
					);


			var storesDataTemplate = new DataTemplate(() =>
			{

                var grid = new Grid();
                grid.BackgroundColor = Color.Blue;
                grid.Padding = 20;

				grid.HorizontalOptions = LayoutOptions.FillAndExpand;

                var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                nameLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
                nameLabel.VerticalOptions = LayoutOptions.CenterAndExpand;
				nameLabel.SetBinding(Label.TextProperty, "name");
                nameLabel.Rotation = 90;


				grid.Children.Add(nameLabel);
				return new ViewCell { View = grid };
			});


	            var listView = new ListView { ItemTemplate = storesDataTemplate, RowHeight=160 };
	            listView.ItemsSource = viewModel.StoresList;
	            listView.SeparatorColor = Color.Transparent;
	            listView.Rotation = 270;
                listView.BackgroundColor = Color.FromHex("#77D065");
			                //listView.Opacity = 0.7;

			      	relativeLayout.Children.Add(listView,
                       // Constraint.Constant(96),
                        Constraint.RelativeToParent((parent) =>
                        {
                            return (parent.Height / 3) - 90 - 50;
                        }),

                        Constraint.RelativeToParent((parent) =>
						{
							return (parent.Height / 3) - 36;
						}),
                                                
                       	Constraint.RelativeToParent(parent => ((parent.Height / 3) - 50) ),
                        Constraint.RelativeToParent((parent) =>
                        {
                            return parent.Width;
                        })
                    );


			var featuredLabel = new Label { FontAttributes = FontAttributes.Bold };
			featuredLabel.Text = "Featured Products";
			featuredLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
			featuredLabel.VerticalOptions = LayoutOptions.CenterAndExpand;

			relativeLayout.Children.Add(featuredLabel,
                            Constraint.RelativeToParent((parent) =>
                            {
                                return parent.X;
                            }),	
                            Constraint.RelativeToView(listView,
							(parent, sibling) =>
							{
								return sibling.Height + 32 + 20 ;
							}),
						Constraint.RelativeToParent(parent => parent.Width),
						Constraint.Constant(36)
					);



			var featuredListDataTemplate = new DataTemplate(() =>
			{
                var contentView = new FeaturedProductViewTemplate();
                return new ViewCell { View = contentView };
			});

            var featuredListView = new ListView { ItemTemplate = featuredListDataTemplate, RowHeight = 160 };
			featuredListView.ItemsSource = viewModel.FeaturedProductsList;
			featuredListView.SeparatorColor = Color.Transparent;
			featuredListView.Rotation = 270;
            featuredListView.BackgroundColor = Color.Gold;


			relativeLayout.Children.Add(featuredListView,
                        Constraint.RelativeToParent((parent) =>
						{
							return (parent.Height / 3) - 90;
						}),

						  Constraint.RelativeToView(listView,
							(parent, sibling) =>
							{
								return sibling.Height ;
							}),

						Constraint.RelativeToParent(parent => (parent.Height / 3) ),
						Constraint.RelativeToParent((parent) =>
						{
							return parent.Width;
						})
					);


			//ScrollView scroll = new ScrollView
			//{
			//	Content = relativeLayout
			//};
			//Content = scroll;
            
            Content = relativeLayout;
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
