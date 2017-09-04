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
    public partial class VideoDetailPage : ContentPage
    {
        public VideoDetailPage()
        {
            InitializeComponent();
        }

        Video video;
        VideoDetailViewModel vm;
        public VideoDetailPage(Video selectedImage, VideoDetailViewModel vm) : this()
        {
            BindingContext = this.video = selectedImage;
            this.vm = vm;
        }


    }
}