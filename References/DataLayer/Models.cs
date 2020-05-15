using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public partial class Landmark
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public string FLargeUrl { get; set; }
        public string FThumbnailUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LargeUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime DateUploaded { get; set; }
    }

    public partial class Location
    {
        public Location()
        {
            Landmarks = new HashSet<Landmark>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Landmark> Landmarks { get; set; }
        public virtual ICollection<UserLocation> UserLocations { get; set; }

    }

    public partial class UserLocation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }

    public partial class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserLocation> UserLocations { get; set; }

    }
}
