using Kiddypi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Firebase.Xamarin.Database;

namespace Kiddypi.Firebase
{
    public class GetStudent
    {

        public  List<Student> Getstudent = new List<Student>();

        // private static Dictionary<object, Student> studentstore = new Dictionary<object, Student>();

        public async Task<string> StudentStorList()
        {

            List<Student> Getstudent = new List<Student>();
            var firebase = new FirebaseClient("https://studentappfirebase-667c5.firebaseio.com/");

            var Items = await firebase.Child("StudentDetails").OnceAsync<Student>();

            //await DisplayAlert("ok", Items.ToString(), "ok");

            foreach (var item in Items)
            {

                Getstudent.Add(item.Object);
            }

            return Items.ToString();
        }


        public async void Connect(object sender, System.EventArgs e)
        {
            var firebase = new FirebaseClient("https://studentappfirebase-667c5.firebaseio.com/");

           // var item = await firebase.Child("StudentDetails").PostAsync(new Student() { StudentName = "Nmdev", Age = "24", DOB = "12/08/2007", StudentID = "66637", Image = "URL" });


        }

        public async void Display()
        {
            
        var firebase = new FirebaseClient("https://studentappfirebase-667c5.firebaseio.com/");

            var Items = await firebase.Child("StudentDetails").OnceAsync<Student>();

            //await DisplayAlert("ok", Items.ToString(), "ok");

            foreach (var item in Items)
            {

                Getstudent.Add(item.Object);
            }
           

        }
        
    }
}