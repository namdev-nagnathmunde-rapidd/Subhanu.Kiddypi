using Kiddypi.Model;
using Kiddypi.ViewModel;
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
    public partial class ImageViewPage : ContentPage
    {
        public ImageViewPage()
        {
            InitializeComponent();
        }

        public ImageViewModel ViewModel { get { return (BindingContext as ImageViewModel); } }




        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Images;
            if (item == null)
                return;

            await Navigation.PushAsync(new ImageDetailPage(item, ViewModel));

            // Manually deselect item
            ImagesListView.SelectedItem = null;
        }

        void OnSyncClicked(object sender, EventArgs e)
        {
            ViewModel?.GetImageCommand?.Execute(null);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel.Imagedetails.Count == 0)
                ViewModel.GetImageCommand.Execute(null);
        }
    }
}