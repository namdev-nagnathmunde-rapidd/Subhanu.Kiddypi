using Kiddypi.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kiddypi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new Kiddypi.MainPage();

           // MainPage = new StudentViewPage();

            MainPage =new ImageViewPage();
        }

        protected override void OnStart()
        {
            // MainPage = new LoginViewPage();
            //MainPage = new FirebaseQueryCheck();
          // MainPage = new ImageViewPage();
       // MainPage = new StudentViewPage();

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
