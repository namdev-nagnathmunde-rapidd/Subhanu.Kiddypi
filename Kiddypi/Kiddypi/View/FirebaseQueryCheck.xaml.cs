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


        private static List<Student> studentstore = new List<Student>();

       // private static Dictionary<object, Student> studentstore = new Dictionary<object, Student>();



        private async void Connect(object sender, System.EventArgs e)
        {
            var firebase = new FirebaseClient("https://studentappfirebase-667c5.firebaseio.com/");

            var item = await firebase.Child("StudentDetails").PostAsync(new Student() { StudentName = "Nmdev", Age = "24" ,DOB="12/08/2007",StudentID="66637",Image="URL"});


        }

        private async void Display(object sender, System.EventArgs e)
        {
            var firebase = new FirebaseClient("https://studentappfirebase-667c5.firebaseio.com/");

            var Items = await firebase.Child("StudentDetails").OnceAsync<Student>();

            //await DisplayAlert("ok", Items.ToString(), "ok");

            foreach(var item in Items)
            {

                studentstore.Add(item.Object);
            }



        }

    }
}