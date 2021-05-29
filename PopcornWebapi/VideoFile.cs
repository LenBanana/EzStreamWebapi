using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopcornWebapi
{
    public class VideoFile
    {
        public double Length { get; set; }
        public string Title { get; set; }
        public string MagnetUrl { get; set; }

        public Uri Banner { get; set; }
        public VideoFile(double Length, string Title, string MagnetUrl, Uri Banner)
        {
            this.Banner = Banner;
            this.Length = Length;
            this.Title = Title;
            this.MagnetUrl = MagnetUrl;
        }
    }
}
