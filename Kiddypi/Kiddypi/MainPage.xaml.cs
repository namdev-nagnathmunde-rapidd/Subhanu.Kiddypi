using Kiddypi.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kiddypi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Task.Delay(3000).Wait();
            Navigation.PushModalAsync(new LoginPage());
        }

    }
}
