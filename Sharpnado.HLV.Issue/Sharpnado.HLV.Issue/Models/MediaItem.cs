using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpnado.HLV.Issue.Models
{
    public class MediaItem
    {
        public MediaItem(bool isVideo, string img, string url = "")
        {
            IsVideo = isVideo;
            ImageURL = img;
            MediaURL = url;
        }
        public bool IsVideo { get; set; }
        public string ImageURL { get; set; }
        public string MediaURL { get; set; }
    }
}
