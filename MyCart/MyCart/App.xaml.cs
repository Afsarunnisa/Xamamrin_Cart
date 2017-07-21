using Xamarin.Forms;

using MyCart.Models;
using MyCart.Views;
using MyCart.Data;



namespace MyCart
{
    public partial class App : Application
    {

        public static ApiManager RestApiManager { get; private set; }


		public App()
        {
            InitializeComponent();
			RestApiManager = new ApiManager(new RestService());


			MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
