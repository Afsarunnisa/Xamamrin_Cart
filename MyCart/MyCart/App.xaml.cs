using Xamarin.Forms;

using MyCart.Models;
using MyCart.Views;
using MyCart.Data;

using MyCart.Library.API;
using MyCart.Library.Modules.Token;
using MyCart.Library.Modules.Identity;



namespace MyCart
{
    public partial class App : Application
    {

        public static ApiManager RestApiManager { get; private set; }


		public App()
        {
            InitializeComponent();

			IdsXamarinApiContext app_context = new IdsXamarinApiContext();
			_ = new IdnSDK(app_context);

			_ = new TokenIdsRegistry();
			_ = new IdentityIdsRegistry();
            App.Current.Properties["UserLogin"] = "false";
			App.Current.Properties["IsSplash"] = "false";


			RestApiManager = new ApiManager(new RestService());


			MainPage = new MainPage();

            //MainPage = new HomePage();

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
