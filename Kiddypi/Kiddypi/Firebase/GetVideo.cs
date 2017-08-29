using Kiddypi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiddypi.Firebase
{
   public  class GetVideo
    {
        public List<Video> GetVideos()
        {
            var List = new List<Video>()
            { new Video
            {  VideoName="VideoName",
                VideoUrl ="URL",
              },
                new Video{
                VideoName ="VideoName1",
                VideoUrl ="URL" } };

            return List;
        }
}
}
