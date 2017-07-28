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
    public class SignUpViewModel : BaseViewModel
    {

		private INavigation _navigation;


		public SignUpViewModel(INavigation navitation)
		{
			_navigation = navitation;
			SignUpUserObject = new SignUpModel();

		}

		#region Properties
		private SignUpModel signUpUserObject;
		/// <summary>
		/// Gets or sets the employee object.
		/// </summary>
		/// <value>The employee object.</value>
		public SignUpModel SignUpUserObject
		{
			get
			{
				return signUpUserObject;
			}
			set
			{
				signUpUserObject = value; OnPropertyChanged();
			}
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
			var signUpUser = SignUpUserObject;

			Type identityApiClass = IDS.getModuleApi("identity");
			object instance = Activator.CreateInstance(identityApiClass);
			IdentityApi identityAPi = instance as IdentityApi;

			
            NewMemberApiModel member = await identityAPi.signUp(signUpUser);

			Debug.WriteLine("member name {0}", member.member.email);
			Debug.WriteLine("member name {0}", member.member.firstName);

   //         if(member.member.email != ""){
   //             //App.Current.Properties["UserLogin"] = true;
			//	App.Current.Properties["UserLogin"] = "true";

			//}

			if (member.member.email != "")
            {
                App.Current.Properties["UserLogin"] = "true";
                App.Current.Properties["NbosToken"] = member.token.access_token;

                var ocValue = await App.RestApiManager.OcConnect();

                Debug.WriteLine("ocValue success {0}", ocValue);

                if(ocValue == true){
                    await _navigation.PushAsync(new AllProductsListPage("0", "0"));
				}

            }

        }

    


        #endregion



    }
}
