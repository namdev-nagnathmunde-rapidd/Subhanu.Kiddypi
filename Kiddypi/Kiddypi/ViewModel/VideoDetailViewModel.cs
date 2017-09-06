using Firebase.Xamarin.Database;
using Kiddypi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kiddypi.ViewModel
{
  public  class VideoDetailViewModel:ViewModelBase
    {
        public string propertyName;

        public ObservableCollection<Video> Videodetails { get; set; }

        public ICommand GetVideoCommand { get; set; }

        public VideoDetailViewModel()
        {
            Videodetails = new ObservableCollection<Video>();
            Title = "Video";
            GetVideoCommand = RefreshCommand = new Command(
                async () => await GetVideos(),
                () => !IsBusy);
        }

        private string[] usercompare = LocalStorage.userstor();

        async Task GetVideos()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                var firebase = new FirebaseClient(Constants.ApplicationURL);

                var Items = await firebase.Child("Videos").OnceAsync<Video>();

                //await DisplayAlert("ok", Items.ToString(), "ok");

                //Load Student into list
                Videodetails.Clear();

                foreach (var item in Items)
                {

                    if (string.Compare(usercompare[0], item.Object.EmailID) == 0)
                    {

                        Videodetails.Add(item.Object);
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

