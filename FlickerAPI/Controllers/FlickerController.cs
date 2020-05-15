using FlickerAPI.Models;
using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlickerAPI.Controllers
{
    public class FlickerController : ApiController
    {    
        // GET api/values/1
        public HttpResponseMessage Get(string id)
        {
            FlickrImageAPI f = new FlickrImageAPI();
            PhotoCollection photos = f.RetrieveImages(id);
            Location location = new Location()
            {
                Name = id,
                Landmarks = photos.Select(p => new Landmark()
                {
                    Title = p.Title,
                    Description = p.Description,
                    DateUploaded = p.DateUploaded,
                    LargeUrl = p.LargeUrl,
                    ThumbnailUrl = p.ThumbnailUrl,
                    FLargeUrl = p.LargeUrl,
                    FThumbnailUrl = p.ThumbnailUrl
                }).ToList()
            };
            return Request.CreateResponse(HttpStatusCode.OK, location);
        }

    }
}
