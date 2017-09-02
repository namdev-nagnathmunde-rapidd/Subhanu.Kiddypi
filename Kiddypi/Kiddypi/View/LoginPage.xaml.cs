using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kiddypi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var nextpage = new FirebaseLoginPage();
            //// await Navigation.PushModalAsync(new MenuPage());

            //await Navigation.PushAsync(nextpage);
            await Navigation.PushModalAsync(new LoginViewPage());
        }
    }
}