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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel.Imagedetails.Count == 0)
                ViewModel.GetImageCommand.Execute(null);
        }
    }
}