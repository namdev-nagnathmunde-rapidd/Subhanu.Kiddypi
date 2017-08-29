
using Firebase.Xamarin.Database;
using Kiddypi.Firebase;
using Kiddypi.Model;
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
 public   class ImageViewModel:ViewModelBase
    {
        public string propertyName;

        public ObservableCollection<Images> Imagedetails { get; set; }

        public ICommand GetImageCommand { get; set; }

        public ImageViewModel()
        {
            Imagedetails = new ObservableCollection<Images>();
            Title = "Images";
            GetImageCommand = RefreshCommand = new Command(
                async () => await GetImages(),
                () => !IsBusy);
        }



        async Task GetImages()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                var firebase = new FirebaseClient("https://studentappfirebase-667c5.firebaseio.com/");

                var Items = await firebase.Child("ImageDetails").OnceAsync<Images>();

                //await DisplayAlert("ok", Items.ToString(), "ok");

                //Load Student into list
                Imagedetails.Clear();

                foreach (var item in Items)
                {

                    Imagedetails.Add(item.Object);
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

