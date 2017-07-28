using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


using MyCart.Views;

using MyCart.Library.Modules.Token;
using MyCart.Library.Modules.Identity;
using MyCart.Library.Modules.IDS;
using MyCart.Library.API.Models;

using Xamarin.Forms;

namespace MyCart.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
		private INavigation _navigation;



		public LoginViewModel(INavigation navitation)
		{
			_navigation = navitation;
			LoginUserObject = new LoginModel();



			Type tokenApiClass = IDS.getModuleApi("token");
			object instance = Activator.CreateInstance(tokenApiClass);
			TokenApi tokenAPi = instance as TokenApi;

			tokenAPi.getClientToken();

		}



		#region Properties
		private LoginModel loginUserObject;
		/// <summary>
		/// Gets or sets the employee object.
		/// </summary>
		/// <value>The employee object.</value>
		public LoginModel LoginUserObject
		{
			get
			{
				return loginUserObject;
			}
			set
			{
				loginUserObject = value; OnPropertyChanged();
			}
		}
		#endregion



		#region DelegateCommand
		Command LoginBtnCommandCommand;
		/// <summary>
		/// Gets the save command.
		/// </summary>
		/// <value>The save command.</value>
		public Command LoginBtnCommand
		{
			get
			{
				return LoginBtnCommandCommand ?? (LoginBtnCommandCommand = new Command(async () => await ExecuteOnLoginClick()));
			}
		}
		#endregion



		#region Methods 

		private async Task ExecuteOnLoginClick()
		{

			var loginUser = LoginUserObject;


			Type identityApiClass = IDS.getModuleApi("identity");
			object instance = Activator.CreateInstance(identityApiClass);
			IdentityApi identityAPi = instance as IdentityApi;

            NewMemberApiModel memberModel =	await identityAPi.login(loginUser);

            Debug.WriteLine("loginUser name {0}", memberModel.member.email);
            Debug.WriteLine("loginUser access_token {0}", memberModel.token.access_token);


			if (memberModel.member.email != "")
			{
				App.Current.Properties["UserLogin"] = "true";
                App.Current.Properties["NbosToken"] = memberModel.token.access_token;

                var ocValue = await App.RestApiManager.OcConnect();

                Debug.WriteLine("ocValue success {0}", ocValue);

				if (ocValue == true)
				{
					await _navigation.PushAsync(new AllProductsListPage("0", "0"));
				}
			}

			Debug.WriteLine("loginUser access_token");


		}

		#endregion


		#region DelegateCommand
		Command SignUpBtnCommandCommand;
		/// <summary>
		/// Gets the save command.
		/// </summary>
		/// <value>The save command.</value>
		public Command SignUpBtnCommand
		{
			get
			{
				return SignUpBtnCommandCommand ?? (SignUpBtnCommandCommand = new Command(async () => await ExecuteOnSignUpClick()));
			}
		}
		#endregion


		#region Methods 

		private async Task ExecuteOnSignUpClick()
		{
			await _navigation.PushAsync(new SignUpPage());
		}

		#endregion
	}
}
