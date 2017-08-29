using Kiddypi.Firebase;
using Kiddypi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kiddypi.ViewModel
{
 public   class ImageViewModel: INotifyPropertyChanged
    {
        public string propertyName;

        public List<Images> ImageList= new List<Images>();

        public List<Images> Imagelist
        {
            get { return ImageList; }
            set
            {
                ImageList = value;
                OnPropertyChanged();
            }
        }

        public ImageViewModel()
        {
            InitializationDataAsync();
        }

        private async Task InitializationDataAsync()
        {
            var getimage = new GetImages();

            ImageList = getimage.GetImage();

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

