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

            var item = await firebase.Child("Sessions").PostAsync(new Session()
            {
                Trainer = "Anand",
                Title = "Scratch Animators and Gamers",
                Location = "Rapidd Technology",
                Abstract = " Scratch is an introductory programming language that enables young children to create their own interactive stories and games. Children snap together graphical programming blocks to make characters move, jump, dance, and sing. Children can modify characters in the paint editor, add their own voices and sounds, even insert photos of themselves  then use the programming blocks to make their characters come to life.",
                Biography = "IOT Trainer at Rapidd Technologies Expert at Creating Animations, Story, Games and Programming ",
                Image = "gs://studentappfirebase-667c5.appspot.com/Session_Images/arduino.jpg",
                TrainerImage = "gs://studentappfirebase-667c5.appspot.com/Trainer_Images/anand.jpg",
                Start = new DateTime(2017, 09, 12, 15, 00, 00),
                End = new DateTime(2017, 09, 12, 18, 00, 00) });


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