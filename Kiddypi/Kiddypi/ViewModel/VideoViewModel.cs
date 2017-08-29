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
   
        public class VideoViewModel : INotifyPropertyChanged
        {
            public string propertyName;

            public List<Video> VideoList = new List<Video>();

            public List<Video> Videolist
            {
                get { return VideoList; }
                set
                {
                VideoList = value;
                    OnPropertyChanged();
                }
            }

            public VideoViewModel()
            {
                InitializationDataAsync();
            }

            private async Task InitializationDataAsync()
            {
                var getvideo = new GetVideo();

            VideoList = getvideo.GetVideos();

            }
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
            {

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }