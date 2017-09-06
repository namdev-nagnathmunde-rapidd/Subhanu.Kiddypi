using Firebase.Xamarin.Database;
using Kiddypi.Model;
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
    public partial class FirebaseQueryCheck : ContentPage
    {
        public FirebaseQueryCheck()
        {
            InitializeComponent();
        }


        private static List<Video> studentstore = new List<Video>();

       // private static Dictionary<object, Student> studentstore = new Dictionary<object, Student>();



        private async void Connect(object sender, System.EventArgs e)
        {
            var firebase = new FirebaseClient("https://studentappfirebase-667c5.firebaseio.com/");

            var item = await firebase.Child("ImageDetails").PostAsync(new Images()
            { ImageName="", EmailID="", ImageUrl="", ImageDescription="", ChildImage_1="", ChildImage_2="", childImage_3="", childImage_4="", childImage_5="" 
                });


        }

        private async void Display(object sender, System.EventArgs e)
        {

            var firebase = new FirebaseClient("https://studentappfirebase-667c5.firebaseio.com/");

            var Items = await firebase.Child("Videos").OnceAsync<Video>();

            //await DisplayAlert("ok", Items.ToString(), "ok");

            foreach(var item in Items)
            {

                studentstore.Add(item.Object);
            }



        }

    }
}