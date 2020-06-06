using API.Models;
using BusinessLayer;
using DataLayer;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class UserService 
    {
        private readonly string secret= "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING"; //place in appsettings json file

        public UserModel Authenticate(AuthenticateModel authenticateModel)
        {
            using (UserRepository repo = new UserRepository())
            {
                var user = repo.Find(authenticateModel.Username, authenticateModel.Password);
                // return null if user not found
                if (user == null)
                    return null;
                if(!user.Activated)//only activated users here
                    return null;
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secret);//_appSettings.Secret;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                       new Claim(ClaimTypes.Name, user.Id.ToString()),
                       new Claim(ClaimTypes.Role, user.Enum_Role.Value)
                    }),
                    Expires = System.DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                UserModel userModel = new UserModel(user);
                var token = tokenHandler.CreateToken(tokenDescriptor);
                userModel.Token = tokenHandler.WriteToken(token);
                userModel.Password = null;
                return userModel;

            }
        }

        public bool Create(UserModel userModel)
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

        public User Read(int id)
        {
            using (UserRepository repo = new UserRepository())
            {
                var data = repo.Read(id);
                data.Password = null;
                return data;
            }
        }

        public void Edit(int id, User item)
        {
            using (UserRepository repo = new UserRepository())
            {
                repo.Edit(id, item);
            }
        }

        public void Delete(int id)
        {
            using (UserRepository repo = new UserRepository())
            {
                repo.Delete(id);
            }
        }

        public List<User> List()
        {
            using (UserRepository repo = new UserRepository())
            {
                var data = repo.List();
                data.ForEach(d =>
                {
                    d.Password = null;
                });
                return data;
            }
        }
    }

    public class EnumService
    {
        public void Create(Enum enumParam)
        {
            using (EnumRepository repo = new EnumRepository())
            {
                repo.Create(enumParam);
            }
        }

        public DataLayer.Enum Read(System.Type type, int key)
        {
            using (EnumRepository repo = new EnumRepository())
            {
                return repo.Read(type, key);
            }
        }

        public void Edit(System.Type type, int key, DataLayer.Enum newEnum)
        {
            using (EnumRepository repo = new EnumRepository())
            {
                 repo.Edit(type, key, newEnum);
            }
        }

        public void Delete(System.Type type, int key)
        {
            using (EnumRepository repo = new EnumRepository())
            {
                repo.Delete(type, key);
            }
        }

        public System.Object List(System.Type type)
        {
            using (EnumRepository repo = new EnumRepository())
            {
                return repo.List(type);
            }
        }
    }

    public class TestCentreService
    {
        public void Create(TestCentre item)
        {
            using (TestCentreRepository repo = new TestCentreRepository())
            {
                repo.Create(item);
            }
        }

        public TestCentre Read(int id)
        {
            using (TestCentreRepository repo = new TestCentreRepository())
            {
                return repo.Read(id);
            }
        }

        public void Edit(int id, TestCentre item)
        {
            using (TestCentreRepository repo = new TestCentreRepository())
            {
                repo.Edit(id, item);
            }
        }

        public void Delete(int id)
        {
            using (TestCentreRepository repo = new TestCentreRepository())
            {
                repo.Delete(id);
            }
        }

        public List<TestCentre> List()
        {
            using (TestCentreRepository repo = new TestCentreRepository())
            {
                return repo.List();
            }
        }
    }

    public class PatientCentreService
    {
        public void Create(Patient item)
        {
            using (PatientRepository repo = new PatientRepository())
            {
                repo.Create(item);
            }
        }

        public Patient Read(int id, int testCentreId)
        {
            using (PatientRepository repo = new PatientRepository())
            {
                return repo.Read(id, testCentreId);
            }
        }

        public void Edit(int id, Patient item, int testCentreId)
        {
            using (PatientRepository repo = new PatientRepository())
            {
                repo.Edit(id, item, testCentreId);
            }
        }

        public void Delete(int id, int testCentreId)
        {
            using (PatientRepository repo = new PatientRepository())
            {
                repo.Delete(id, testCentreId);
            }
        }

        public List<Patient> List(int testCentreId)
        {
            using (PatientRepository repo = new PatientRepository())
            {
                return repo.List(testCentreId);
            }
        }
    }

    public class NextOfKinService
    {
        public void Create(NextOfKin item)
        {
            using (NextOfKinRepository repo = new NextOfKinRepository())
            {
                repo.Create(item);
            }
        }

        public NextOfKin Read(int id)
        {
            using (NextOfKinRepository repo = new NextOfKinRepository())
            {
                return repo.Read(id);
            }
        }

        public void Edit(int id, NextOfKin item)
        {
            using (NextOfKinRepository repo = new NextOfKinRepository())
            {
                repo.Edit(id, item);
            }
        }

        public void Delete(int id)
        {
            using (NextOfKinRepository repo = new NextOfKinRepository())
            {
                repo.Delete(id);
            }
        }

        public List<NextOfKin> List()
        {
            using (NextOfKinRepository repo = new NextOfKinRepository())
            {
                return repo.List();
            }
        }
    }
    
    public class PortOfEntryService
    {
        public void Create(PortOfEntry item)
        {
            using (PortOfEntryRepository repo = new PortOfEntryRepository())
            {
                repo.Create(item);
            }
        }

        public PortOfEntry Read(int id)
        {
            using (PortOfEntryRepository repo = new PortOfEntryRepository())
            {
                return repo.Read(id);
            }
        }

        public void Edit(int id, PortOfEntry item)
        {
            using (PortOfEntryRepository repo = new PortOfEntryRepository())
            {
                repo.Edit(id, item);
            }
        }

        public void Delete(int id)
        {
            using (PortOfEntryRepository repo = new PortOfEntryRepository())
            {
                repo.Delete(id);
            }
        }

        public List<PortOfEntry> List()
        {
            using (PortOfEntryRepository repo = new PortOfEntryRepository())
            {
                return repo.List();
            }
        }
    }

    public class CentreService
    {
        public void Create(Centre item)
        {
            using (CentreRepository repo = new CentreRepository())
            {
                repo.Create(item);
            }
        }

        public Centre Read(int id)
        {
            using (CentreRepository repo = new CentreRepository())
            {
                return repo.Read(id);
            }
        }

        public void Edit(int id, Centre item)
        {
            using (CentreRepository repo = new CentreRepository())
            {
                repo.Edit(id, item);
            }
        }

        public void Delete(int id)
        {
            using (CentreRepository repo = new CentreRepository())
            {
                repo.Delete(id);
            }
        }

        public List<Centre> List()
        {
            using (CentreRepository repo = new CentreRepository())
            {
                return repo.List();
            }
        }
    }

    public class CaptureHistoryService
    {
        public void Create(CaptureHistory item)
        {
            using (CaptureHistoryRepository repo = new CaptureHistoryRepository())
            {
                repo.Create(item);
            }
        }

        public CaptureHistory Read(int id)
        {
            using (CaptureHistoryRepository repo = new CaptureHistoryRepository())
            {
                return repo.Read(id);
            }
        }

        public void Edit(int id, CaptureHistory item)
        {
            using (CaptureHistoryRepository repo = new CaptureHistoryRepository())
            {
                repo.Edit(id, item);
            }
        }

        public void Delete(int id)
        {
            using (CaptureHistoryRepository repo = new CaptureHistoryRepository())
            {
                repo.Delete(id);
            }
        }

        public List<CaptureHistory> List()
        {
            using (CaptureHistoryRepository repo = new CaptureHistoryRepository())
            {
                return repo.List();
            }
        }
    }

    public class CentreHistoryService
    {
        public void Create(CentreHistory item)
        {
            using (CentreHistoryRepository repo = new CentreHistoryRepository())
            {
                repo.Create(item);
            }
        }

        public CentreHistory Read(int id)
        {
            using (CentreHistoryRepository repo = new CentreHistoryRepository())
            {
                return repo.Read(id);
            }
        }

        public void Edit(int id, CentreHistory item)
        {
            using (CentreHistoryRepository repo = new CentreHistoryRepository())
            {
                repo.Edit(id, item);
            }
        }

        public void Delete(int id)
        {
            using (CentreHistoryRepository repo = new CentreHistoryRepository())
            {
                repo.Delete(id);
            }
        }

        public List<CentreHistory> List()
        {
            using (CentreHistoryRepository repo = new CentreHistoryRepository())
            {
                return repo.List();
            }
        }
    }
}
