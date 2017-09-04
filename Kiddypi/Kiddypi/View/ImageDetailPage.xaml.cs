using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiddypi.Model;
using Kiddypi.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kiddypi.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageDetailPage : ContentPage
	{
        
        public ImageDetailPage ()
		{
			InitializeComponent ();
		}


        Images Image;
        ImageViewModel vm;
        public ImageDetailPage(Images selectedImage, ImageViewModel vm) : this()
        {
            BindingContext = this.Image = selectedImage;
            this.vm = vm;
        }

    }
}