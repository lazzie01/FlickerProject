using System;
using System.Collections.Generic;

namespace FlickerAPI.Models
{
    public partial class Location
    {
        public Location()
        {
            Landmarks = new HashSet<Landmark>();
        }
        public string Name { get; set; }
        public virtual ICollection<Landmark> Landmarks { get; set; }
    }

    public partial class Landmark
    {
        public string FLargeUrl { get; set; }
        public string FThumbnailUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LargeUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}