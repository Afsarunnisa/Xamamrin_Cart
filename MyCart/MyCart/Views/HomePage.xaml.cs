using System;
using System.Collections.Generic;

using Xamarin.Forms;

using MyCart.Controls;
using MyCart.ViewModel;

namespace MyCart.Views
{
    public partial class HomePage : ContentPage
    {

        View _tabs;

        RelativeLayout relativeLayout;

        CarouselLayout.IndicatorStyleEnum _indicatorStyle;

        SwitcherPageViewModel viewModel;


        public HomePage()
        {
            _indicatorStyle = CarouselLayout.IndicatorStyleEnum.Dots;

            viewModel = new SwitcherPageViewModel();
            BindingContext = viewModel;

            Title = _indicatorStyle.ToString();

            relativeLayout = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var pagesCarousel = CreatePagesCarousel();
            var dots = CreatePagerIndicatorContainer();

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
                            return parent.Height / 2;
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
