using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }

        public UserModel() { }

        public UserModel(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Password = user.Password;
        }

        public User ToModel()
        {
            return new User()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Username = Username,
                Password = Password,
            };
        }
    }

    public class LocationModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public LocationModel() { }

        public LocationModel(Location location)
        {
            Id = location.Id;
            Name = location.Name;
        }

        public Location ToModel()
        {
            return new Location()
            {
                Id = Id,
                Name = Name
            };
        }
    }

    public class SearchModel
    {
        [Required]
        public string Query { get; set; }

        [Required]
        public int Id { get; set; }
    }

    public partial class LandmarkModel
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string FLargeUrl { get; set; }
        public string FThumbnailUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LargeUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime DateUploaded { get; set; }

        public LandmarkModel()
        {

        }

        public LandmarkModel(Landmark landmark)
        {
            Id = landmark.Id;
            LocationId = landmark.LocationId;
            FLargeUrl = landmark.FLargeUrl;
            FThumbnailUrl = landmark.FThumbnailUrl;
            Title = landmark.Title;
            Description = landmark.Description;
            LargeUrl = landmark.LargeUrl;
            ThumbnailUrl = landmark.ThumbnailUrl;
            DateUploaded = landmark.DateUploaded;
        }

        public Landmark ToModel()
        {
            return new Landmark()
            {
                Id = Id,
                LocationId = LocationId,
                FLargeUrl = FLargeUrl,
                FThumbnailUrl = FThumbnailUrl,
                Title = Title,
                Description = Description,
                LargeUrl = LargeUrl,
                ThumbnailUrl = ThumbnailUrl,
                DateUploaded = DateUploaded
            };
        }
    }
}
