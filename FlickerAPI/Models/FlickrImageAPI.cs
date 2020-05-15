using FlickrNet;
using System;
using System.Configuration;

namespace FlickerAPI.Models
{
    public class FlickrImageAPI
    {
        string flickrKey = ConfigurationManager.AppSettings["flickrKey"];
        string sharedSecret = ConfigurationManager.AppSettings["sharedSecret"];

        public PhotoCollection RetrieveImages(string tag)
        {
            PhotoSearchOptions options = new PhotoSearchOptions();
            options.PerPage = Int32.Parse(ConfigurationManager.AppSettings["pageSize"]);
            options.Page = 1;
            options.SortOrder = PhotoSearchSortOrder.DatePostedDescending;
            options.MediaType = MediaType.Photos;
            options.Extras = PhotoSearchExtras.All;
            options.Tags = tag;
            Flickr flickr = new Flickr(flickrKey, sharedSecret);
            PhotoCollection photos = flickr.PhotosSearch(options);
            return photos;
        }
    }
}