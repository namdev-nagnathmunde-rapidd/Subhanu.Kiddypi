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
	public partial class FirebaseLoginPage : ContentPage
	{
		public FirebaseLoginPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {

            var nextpage = new StudentViewPage();
            await Navigation.PushModalAsync(new MenuPage());

        }
    }
}