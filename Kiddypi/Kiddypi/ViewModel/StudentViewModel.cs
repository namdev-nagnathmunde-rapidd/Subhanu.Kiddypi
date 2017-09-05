using Firebase.Xamarin.Database;
using Kiddypi.Firebase;
using Kiddypi.Model;
using Kiddypi.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kiddypi.ViewModel
{

    public class StudentViewModel : ViewModelBase
    {
        public string propertyName;

        LoginViewPage getuniquestudent = new LoginViewPage();

       // public string  user_check= getuniquestudent.Focus


        public ObservableCollection<Student> Studentdetails { get; set; }

        public ICommand GetStudentCommand { get; set; }
       
       

        public StudentViewModel()
        {
            Studentdetails = new ObservableCollection<Student>();
            Title = "Student";
            GetStudentCommand = RefreshCommand = new Command(
                async () => await GetStudents(),
                () => !IsBusy);
        }


        LocalStorage UserCall = new LocalStorage();

        private string[] usercompare = LocalStorage.userstor();

        async Task GetStudents()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                var firebase = new FirebaseClient(Constants.ApplicationURL);

                var Items = await firebase.Child("StudentDetails").OnceAsync<Student>();

                //await DisplayAlert("ok", Items.ToString(), "ok");

                //Load Student into list
                Studentdetails.Clear();

                foreach (var item in Items)
                {
                    if (string.Compare(usercompare[0], item.Object.EmailID) == 0)
                    {

                        Studentdetails.Add(item.Object);
                    }           
                }
            }
            catch (Exception ex)
            {
               // Debug.WriteLine("Error: " + ex);
                error = ex;
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");

            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
        }

    }

}


