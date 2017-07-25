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


using Xamarin.Forms;

using MyCart.Models;


namespace MyCart.ViewModel
{
    public class GuestCheckOutViewModel : INotifyPropertyChanged
    {

		public GuestUser GuestUserResult { get; private set; }
		public ICommand NextBtnCommand { get; private set; }

		public GuestCheckOutViewModel()
        {
            NextBtnCommand = new Command<GuestUser> (GuestCheckOutNext);
        }

        void GuestCheckOutNext(GuestUser guestUser){

            Debug.WriteLine("name {0}", guestUser.firstname);


			OnPropertyChanged("GuestUserResult");

		}

		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	}
}
