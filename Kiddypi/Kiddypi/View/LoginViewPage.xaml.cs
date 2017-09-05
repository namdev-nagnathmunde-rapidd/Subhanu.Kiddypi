using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kiddypi.Model;
using Firebase.Xamarin.Database;

namespace Kiddypi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginViewPage : ContentPage
    {
        public LoginViewPage()
        {
            InitializeComponent();
        }
             
       

        // public ObservableCollection<UserLogin> UserDetails { get; set; }
        private List<UserLogin> UserDetails = new List<UserLogin>();


        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new SignUpPage());
        }


        async void OnLoginButtonClicked(object sender, EventArgs e)
        {

            LocalStorage.UserComparedetails[0]=(UserEmailEntry.Text);

            var user = new UserCompare
            {
                CompareEmail = UserEmailEntry.Text,
                ComparePassword = passwordEntry.Text
            };

           
           

               



            Exception error = null;
            try
            {

                var firebase = new FirebaseClient(Constants.ApplicationURL);

                var Items = await firebase.Child("UserLogin").OnceAsync<UserLogin>();

                //await DisplayAlert("ok", Items.ToString(), "ok");

                foreach (var item in Items)
                {
                    UserDetails.Add(item.Object);
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



            var isValid = AreCredentialsCorrect(user, UserDetails);
            if (isValid)
            {
                App.IsUserLoggedIn = true;

                //MainPage = App.ManuPage;
                //  Navigation.InsertPageBefore(new StudentViewPage(), this);
                //await Navigation.PopAsync();

                //  await Navigation.PushAsync(new StudentViewPage());

                var nextpage = new StudentViewPage();
                await Navigation.PushModalAsync(new MenuPage());

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error!", "Login failed  Please Try Again", "OK");

              //  messageLabel.Text = "Login failed  Please Try Again";
                passwordEntry.Text = string.Empty;

            }
        }

        bool AreCredentialsCorrect(UserCompare user, List<UserLogin> userdetails)
        {
            bool Resp = false;
            foreach (UserLogin firebaseuser in userdetails)
            {
                

                if (string.Compare(user.CompareEmail, firebaseuser.UserEmail) == 0 && string.Compare(user.ComparePassword, firebaseuser.Password) == 0)
                {
                    Resp = true;

                    break;
                }
                else
                {
                    Resp = false;
                    continue;
                }
            }
            return Resp;

        }

        
    }


}


