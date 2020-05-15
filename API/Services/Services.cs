using API.Helpers;
using API.Models;
using BusinessLayer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public interface IService
    {
        UserModel AuthenticateUser(AuthenticateModel authenticateModel);

        bool RegisterUser(UserModel userModel);

        List<LocationModel> GetLocations(int id);

        void AddLocation(SearchModel searchModel, string folderPath);

        List<LandmarkModel> GetLocationLandmarks(int id, string imageFolderPath);

        LandmarkModel GetLandmark(int id, string imageFolderPath);

        void DeleteLocation(int userId, int locationId);

    }

    public class Service : IService
    {
        private readonly AppSettings _appSettings;
       
        public Service(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserModel AuthenticateUser(AuthenticateModel authenticateModel)
        {
            using (UserRepository repo = new UserRepository())
            {
                var user = repo.Find(authenticateModel.Username, authenticateModel.Password);
                // return null if user not found
                if (user == null)
                    return null;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                UserModel userModel = new UserModel(user);
                var token = tokenHandler.CreateToken(tokenDescriptor);
                userModel.Token = tokenHandler.WriteToken(token);
                userModel.Password = null;
                return userModel;

            }
        }

        public bool RegisterUser(UserModel userModel)
        {
            using (UserRepository repo = new UserRepository())
            {
                if (repo.Find(userModel.Username) == null)
                {
                    repo.Create(userModel.ToModel());
                    return true;
                }
                return false;
            }
        }

        public List<LocationModel> GetLocations(int id)
        {
            using (UserRepository repo = new UserRepository())
            {
                var data = repo.Locations(id);
                if(data==null)
                    return null;
                return data.Select(l => new LocationModel(l)).ToList();
            }
        }

        public void AddLocation(SearchModel searchModel, string folderPath)
        {
            using (LocationRepository repo = new LocationRepository())
            {    
                if(!string.IsNullOrEmpty(searchModel.Query))
                repo.Create(searchModel.Id, searchModel.Query, folderPath);
            }
        }

        public List<LandmarkModel> GetLocationLandmarks(int id, string imageFolderPath)
        {
            using (LandmarkRepository repo = new LandmarkRepository())
            {
                var data = repo.List(id);
                data.ForEach(l =>
                {
                    l.FLargeUrl = "data:image/jpeg;base64, " + Convert.ToBase64String(File.ReadAllBytes(imageFolderPath + l.FLargeUrl));
                    l.FThumbnailUrl = "data:image/jpeg;base64, " + Convert.ToBase64String(File.ReadAllBytes(imageFolderPath + l.FThumbnailUrl));
                });
                return data.Select(l => new LandmarkModel(l)).ToList();
            }
        }

        public LandmarkModel GetLandmark(int id, string imageFolderPath)
        {
            using (LandmarkRepository repo = new LandmarkRepository())
            {
                //imageFolderPath
                return new LandmarkModel(repo.Read(id));
            }
        }

        public void DeleteLocation(int userId, int locationId)
        {
            using(UserLocationRepository repo = new UserLocationRepository())
            {
                repo.Delete(userId, locationId);
            }
        }
    }
}
