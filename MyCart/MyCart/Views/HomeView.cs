using System;
using Xamarin.Forms;


namespace MyCart.Views
{
    public class HomeView : ContentView
    {
        public HomeView()
        {
			BackgroundColor = Color.White;

			var label = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				TextColor = Color.Black
			};

            var image = new Image
            {
                Aspect = Aspect.AspectFit
            };

			label.SetBinding(Label.TextProperty, "Title");
			this.SetBinding(ContentView.BackgroundColorProperty, "Background");
            image.SetBinding(Image.SourceProperty, "ImageSource");



			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					image
				}
			};

        }
    }
}
