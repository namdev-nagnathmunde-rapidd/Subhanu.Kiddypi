using Firebase.Xamarin.Database;
using Kiddypi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kiddypi.ViewModel
{
   public class SessionsViewModel:ViewModelBase
    {

        public ObservableCollection<Session> Sessions { get; set; }

        public ICommand GetSessionsCommand { get; set; }

        public SessionsViewModel()
        {
            Sessions = new ObservableCollection<Session>();
            Title = "Sessions";
            GetSessionsCommand = RefreshCommand = new Command(
                async () => await GetSessions(),
                () => !IsBusy);
        }

        async Task GetSessions()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                var firebase = new FirebaseClient(Constants.ApplicationURL);

                var Items = await firebase.Child("Sessions").OnceAsync<Session>();

                //await DisplayAlert("ok", Items.ToString(), "ok");

                //Load Student into list
                Sessions.Clear();

                foreach (var item in Items)
                {
                        Sessions.Add(item.Object);          
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
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
