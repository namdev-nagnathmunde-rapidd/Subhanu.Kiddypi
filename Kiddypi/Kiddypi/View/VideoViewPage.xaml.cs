using Kiddypi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiddypi.ViewModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kiddypi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoViewPage : ContentPage
    {
        public VideoViewPage()
        {
            InitializeComponent();
        }
        public VideoDetailViewModel ViewModel { get { return (BindingContext as VideoDetailViewModel); } }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Video ;
            if (item == null)
                return;

            await Navigation.PushAsync(new VideoDetailPage(item, ViewModel));

            // Manually deselect item
            VideoListView.SelectedItem = null;
        }

        void OnSyncClicked(object sender, EventArgs e)
        {
            ViewModel?.GetVideoCommand?.Execute(null);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel.Videodetails.Count == 0)
                ViewModel.GetVideoCommand.Execute(null);
        }
    }
}