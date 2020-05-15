using DataLayer;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace BusinessLayer
{
    public class BaseRepository : IDisposable
    {
        protected ApplicationDbContext DB { get; }

        public BaseRepository()
        {
            DB = new ApplicationDbContext();
        }

        public BaseRepository(BaseRepository callingRepo)
        {
            DB = callingRepo.DB;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            if (!disposedValue)
            {
                DB.Dispose();
                disposedValue = true;
            }
        }
        #endregion
    }

    public class UserRepository : BaseRepository
    {
        public UserRepository() : base() { }

        public UserRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public void Create(User user)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            user.Password = passwordHasher.HashPassword(user.Password);
            DB.Users.Add(user);
            DB.SaveChanges();
        }

        public User Find(string username, string password)
        {          
            var user = DB.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                PasswordHasher passwordHasher = new PasswordHasher();

                var result= passwordHasher.VerifyHashedPassword(user.Password, password);
                if(result == PasswordVerificationResult.Success)
                {
                    return user;
                }

                return null;
            }
            return null;
        }

        public User Find(string username)
        {
            return DB.Users.FirstOrDefault(u => u.Username == username);      
        }

        public List<Location> Locations(int id)
        {
            var data = DB.UserLocations.Include(x => x.Location).Where(u => u.UserId == id).ToList();
            if (data.Any())
            {
                return data.Select(d => d.Location).ToList();
            }
            return null;
        }
    }

    public class UserLocationRepository : BaseRepository
    {
        public UserLocationRepository() : base() { }

        public UserLocationRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public void Create(int userId, int locationId)
        {
            if (!DB.UserLocations.Any(u => u.UserId == userId && u.LocationId == locationId))
            {
                UserLocation userLocation = new UserLocation()
                {
                    UserId = userId,
                    LocationId = locationId
                };
                DB.UserLocations.Add(userLocation);
            }
        }

        public void Delete(int userId, int locationId)
        {
            var location = DB.UserLocations.FirstOrDefault(u => u.UserId == userId && u.LocationId == locationId);
            if(location!=null)
            DB.UserLocations.Remove(location);
            DB.SaveChanges();
        }

    }

    public class LocationRepository : BaseRepository
    {
        public LocationRepository() : base() { }

        public LocationRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public List<Location> List()
        {
            return DB.Locations.ToList();
        }

        public Location Read(int id)
        {
            return DB.Locations.FirstOrDefault(x => x.Id == id);
        }

        public void Create(int id, string name, string path)
        {
            UserLocation userLocation = null;
            if (!DB.Locations.Any(l => l.Name.ToLower().Equals(name.ToLower())))
            {    
                var location = JsonSerializer.Deserialize<Location>(FlickerClient.Search(name));
                location.Landmarks.ToList().ForEach(l =>
                {
                    l.FLargeUrl = FileNameGenerator.RandomName(l.LargeUrl);
                    l.FThumbnailUrl = FileNameGenerator.RandomName(l.ThumbnailUrl);
                });

                userLocation = new UserLocation()
                {
                    UserId = id,
                    Location = location
                };
                DB.UserLocations.Add(userLocation);
                DB.SaveChanges();
                //save the images to a location in the computer, i.e folder
                WebClient webClient = new WebClient();
                location.Landmarks.ToList().ForEach(landmark =>
                {
                    webClient.DownloadFile(landmark.LargeUrl, path + landmark.FLargeUrl);
                    webClient.DownloadFile(landmark.ThumbnailUrl, path + landmark.FThumbnailUrl);
                });
            }
            else
            {
                var existingLocation = DB.Locations.FirstOrDefault(l => l.Name.ToLower().Equals(name.ToLower()));
                userLocation = new UserLocation()
                {
                    UserId = id,
                    Location = existingLocation
                };
                DB.UserLocations.Add(userLocation);
                DB.SaveChanges();
            }
        }

    }

    public class LandmarkRepository : BaseRepository
    {
        public LandmarkRepository() : base() { }

        public LandmarkRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public Landmark Read(int id)
        {
            return DB.Landmarks.FirstOrDefault(x => x.Id == id);
        }

        public List<Landmark> List(int id=0)
        {
            if(id==0)
                return DB.Landmarks.ToList();
            return DB.Landmarks.Where(l=>l.LocationId==id).ToList();
        }
    }
 
}
