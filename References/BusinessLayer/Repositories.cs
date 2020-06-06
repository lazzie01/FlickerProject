using DataLayer;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

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
    
    public class EnumRepository : BaseRepository
    {
        public EnumRepository() : base() { }

        public EnumRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public void Create(DataLayer.Enum enumType)
        {
            Type type = enumType.GetType();
            if (type == typeof(Enum_Organization))
            {
                DB.Enum_Organizations.Add(enumType as Enum_Organization);
            }

            else if (type == typeof(Enum_Department))
            {
                DB.Enum_Departments.Add(enumType as Enum_Department);
            }
            
            else if (type == typeof(Enum_Role))
            {
                DB.Enum_Roles.Add(enumType as Enum_Role);
            }

            else if (type == typeof(Enum_IdType))
            {
                DB.Enum_IdTypes.Add(enumType as Enum_IdType);
            }

            else if (type == typeof(Enum_Province))
            {
                DB.Enum_Provinces.Add(enumType as Enum_Province);
            }

            else if (type == typeof(Enum_Country))
            {
                DB.Enum_Countries.Add(enumType as Enum_Country);
            }

            else if (type == typeof(Enum_PortOfEntry))
            {
                DB.Enum_PortOfEntries.Add(enumType as Enum_PortOfEntry);
            }

            else if (type == typeof(Enum_CovidStatus))
            {
                DB.Enum_CovidStatuses.Add(enumType as Enum_CovidStatus);
            }

            else if (type == typeof(Enum_HIVStatus))
            {
                DB.Enum_HIVStatuses.Add(enumType as Enum_HIVStatus);
            }

            else if (type == typeof(Enum_PatientStatus))
            {
                DB.Enum_PatientStatuses.Add(enumType as Enum_PatientStatus);
            }

            else if (type == typeof(Enum_Sex))
            {
                DB.Enum_Sexes.Add(enumType as Enum_Sex);
            }

            else if (type == typeof(Enum_Town))
            {
                DB.Enum_Towns.Add(enumType as Enum_Town);
            }
            DB.SaveChanges();
        }

        public DataLayer.Enum Read(Type type, int key)
        {
            if (type == typeof(Enum_Organization))
            {
                return DB.Enum_Organizations.FirstOrDefault(f=>f.Key==key);
            }

            else if (type == typeof(Enum_Department))
            {
                return DB.Enum_Departments.FirstOrDefault(f => f.Key == key);
            }

            else if (type == typeof(Enum_Role))
            {
                return DB.Enum_Roles.FirstOrDefault(f => f.Key == key);
            }

            else if (type == typeof(Enum_IdType))
            {
                return DB.Enum_IdTypes.FirstOrDefault(f => f.Key == key);
            }

            else if (type == typeof(Enum_Province))
            {
                return DB.Enum_Provinces.FirstOrDefault(f => f.Key == key);
            }

            else if (type == typeof(Enum_Country))
            {
                return DB.Enum_Countries.FirstOrDefault(f => f.Key == key);
            }

            else if (type == typeof(Enum_PortOfEntry))
            {
                return DB.Enum_PortOfEntries.FirstOrDefault(f => f.Key == key);
            }

            else if (type == typeof(Enum_CovidStatus))
            {
                return DB.Enum_CovidStatuses.FirstOrDefault(f => f.Key == key);
            }

            else if (type == typeof(Enum_HIVStatus))
            {
                return DB.Enum_HIVStatuses.FirstOrDefault(f => f.Key == key);
            }

            else if (type == typeof(Enum_PatientStatus))
            {
                return DB.Enum_PatientStatuses.FirstOrDefault(f => f.Key == key);
            }

            else if (type == typeof(Enum_Sex))
            {
                return DB.Enum_Sexes.FirstOrDefault(f => f.Key == key);
            }

            else if (type == typeof(Enum_Town))
            {
                return DB.Enum_Towns.FirstOrDefault(f => f.Key == key);
            }

            return null;
        }

        public void Edit(Type type, int key, DataLayer.Enum newEnum)
        {
            if (type == typeof(Enum_Organization))
            {
                var item =  DB.Enum_Organizations.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }

            else if (type == typeof(Enum_Department))
            {
                var item =  DB.Enum_Departments.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }

            else if (type == typeof(Enum_Role))
            {
                var item = DB.Enum_Roles.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }

            else if (type == typeof(Enum_IdType))
            {
                var item = DB.Enum_IdTypes.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }

            else if (type == typeof(Enum_Province))
            {
                var item = DB.Enum_Provinces.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }

            else if (type == typeof(Enum_Country))
            {
                var item = DB.Enum_Countries.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }

            else if (type == typeof(Enum_PortOfEntry))
            {
                var item = DB.Enum_PortOfEntries.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }

            else if (type == typeof(Enum_CovidStatus))
            {
                var item = DB.Enum_CovidStatuses.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }

            else if (type == typeof(Enum_HIVStatus))
            {
                var item = DB.Enum_HIVStatuses.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }

            else if (type == typeof(Enum_PatientStatus))
            {
                var item = DB.Enum_PatientStatuses.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }

            else if (type == typeof(Enum_Sex))
            {
                var item = DB.Enum_Sexes.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }

            else if (type == typeof(Enum_Town))
            {
                var item = DB.Enum_Towns.FirstOrDefault(f => f.Key == key);
                if (item != null)
                {
                    item.Value = newEnum.Value;
                }
            }
            DB.SaveChanges();
        }

        public void Delete(Type type, int key=0)
        {
            if (type == typeof(Enum_Organization))
            {
                if (key == 0)
                {
                    DB.Enum_Organizations.RemoveRange(DB.Enum_Organizations.ToList());
                }
                else
                {
                    var item = DB.Enum_Organizations.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_Organizations.Remove(item);
                    }
                }
            }

            else if (type == typeof(Enum_Department))
            {
                if (key == 0)
                {
                    DB.Enum_Departments.RemoveRange(DB.Enum_Departments.ToList());
                }
                else
                {
                    var item = DB.Enum_Departments.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_Departments.Remove(item);
                    }
                }
            }

            else if (type == typeof(Enum_Role))
            {
                if (key == 0)
                {
                    DB.Enum_Roles.RemoveRange(DB.Enum_Roles.ToList());
                }
                else
                {
                    var item = DB.Enum_Roles.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_Roles.Remove(item);
                    }
                }
            }

            else if (type == typeof(Enum_IdType))
            {
                if (key == 0)
                {
                    DB.Enum_IdTypes.RemoveRange(DB.Enum_IdTypes.ToList());
                }
                else
                {
                    var item = DB.Enum_IdTypes.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_IdTypes.Remove(item);
                    }
                }
            }

            else if (type == typeof(Enum_Province))
            {
                if (key == 0)
                {
                    DB.Enum_Provinces.RemoveRange(DB.Enum_Provinces.ToList());
                }
                else
                {
                    var item = DB.Enum_Provinces.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_Provinces.Remove(item);
                    }
                }
            }

            else if (type == typeof(Enum_Country))
            {
                if (key == 0)
                {
                    DB.Enum_Countries.RemoveRange(DB.Enum_Countries.ToList());
                }
                else
                {
                    var item = DB.Enum_Countries.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_Countries.Remove(item);
                    }
                }
            }

            else if (type == typeof(Enum_PortOfEntry))
            {
                if (key == 0)
                {
                    DB.Enum_PortOfEntries.RemoveRange(DB.Enum_PortOfEntries.ToList());
                }
                else
                {
                    var item = DB.Enum_PortOfEntries.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_PortOfEntries.Remove(item);
                    }
                }
            }

            else if (type == typeof(Enum_CovidStatus))
            {
                if (key == 0)
                {
                    DB.Enum_CovidStatuses.RemoveRange(DB.Enum_CovidStatuses.ToList());
                }
                else
                {
                    var item = DB.Enum_CovidStatuses.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_CovidStatuses.Remove(item);
                    }
                }
            }

            else if (type == typeof(Enum_HIVStatus))
            {
                if (key == 0)
                {
                    DB.Enum_HIVStatuses.RemoveRange(DB.Enum_HIVStatuses.ToList());
                }
                else
                {
                    var item = DB.Enum_HIVStatuses.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_HIVStatuses.Remove(item);
                    }
                }
            }

            else if (type == typeof(Enum_PatientStatus))
            {
                if (key == 0)
                {
                    DB.Enum_PatientStatuses.RemoveRange(DB.Enum_PatientStatuses.ToList());
                }
                else
                {
                    var item = DB.Enum_PatientStatuses.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_PatientStatuses.Remove(item);
                    }
                }
            }

            else if (type == typeof(Enum_Sex))
            {
                if (key == 0)
                {
                    DB.Enum_Sexes.RemoveRange(DB.Enum_Sexes.ToList());
                }
                else
                {
                    var item = DB.Enum_Sexes.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_Sexes.Remove(item);
                    }
                }
            }

            else if (type == typeof(Enum_Town))
            {
                if (key == 0)
                {
                    DB.Enum_Towns.RemoveRange(DB.Enum_Towns.ToList());
                }
                else
                {
                    var item = DB.Enum_Towns.FirstOrDefault(f => f.Key == key);
                    if (item != null)
                    {
                        DB.Enum_Towns.Remove(item);
                    }
                }
            }
            DB.SaveChanges();
        }

        public Object List(Type type)
        {
            if (type == typeof(Enum_Organization))
            {
                return DB.Enum_Organizations.ToList();
            }

            else if (type == typeof(Enum_Department))
            {
                return DB.Enum_Departments.ToList();
            }

            else if (type == typeof(Enum_Role))
            {
                return DB.Enum_Roles.ToList();
            }

            else if (type == typeof(Enum_IdType))
            {
                return DB.Enum_IdTypes.ToList();
            }

            else if (type == typeof(Enum_Province))
            {
                return DB.Enum_Provinces.ToList();
            }

            else if (type == typeof(Enum_Country))
            {
                return DB.Enum_Countries.ToList();
            }

            else if (type == typeof(Enum_PortOfEntry))
            {
                return DB.Enum_PortOfEntries.ToList();
            }

            else if (type == typeof(Enum_CovidStatus))
            {
                return DB.Enum_CovidStatuses.ToList();
            }

            else if (type == typeof(Enum_HIVStatus))
            {
                return DB.Enum_HIVStatuses.ToList();
            }

            else if (type == typeof(Enum_PatientStatus))
            {
                return DB.Enum_PatientStatuses.ToList();
            }

            else if (type == typeof(Enum_Sex))
            {
                return DB.Enum_Sexes.ToList();
            }

            else if (type == typeof(Enum_Town))
            {
                return DB.Enum_Towns.ToList();
            }

            return null;
        }
    }

    public class TestCentreRepository : BaseRepository
    {
        public TestCentreRepository() : base() { }

        public TestCentreRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public void Create(TestCentre item)
        {
            DB.TestCentres.Add(item);
            DB.SaveChanges();
        }

        public TestCentre Read(int id)
        {
            return DB.TestCentres.FirstOrDefault(f => f.Id == id);
        }

        public void Edit(int id, TestCentre item)
        {
            var itemToEdit = DB.TestCentres.FirstOrDefault(f => f.Id == id);
            if (itemToEdit != null)
            {
                itemToEdit.Name = item.Name;
                itemToEdit.Address = item.Address;
                itemToEdit.Phone = item.Phone;
                itemToEdit.MenCapacity = item.MenCapacity;
                itemToEdit.WomenCapacity = item.WomenCapacity;
            }
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = DB.TestCentres.FirstOrDefault(f => f.Id == id);
            if (item != null)
            {
                DB.TestCentres.Remove(item);
                DB.SaveChanges();
            }
        }

        public List<TestCentre> List()
        {
            return DB.TestCentres.ToList();
        }
    }

    public class PatientRepository : BaseRepository
    {
        public PatientRepository() : base() { }

        public PatientRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public void Create(Patient item)
        {
            DB.Patients.Add(item);
            DB.SaveChanges();
        }

        public Patient Read(int id, int testCentreId)
        {
            var data = DB.Patients
                         .Include(p => p.Enum_Province)
                         .Include(p => p.Enum_NationalityCountry)
                         .Include(p => p.Enum_PreviousCountry)
                         .Include(p => p.Enum_Sex)
                         .Include(p => p.Enum_IdType)
                         .Include(p => p.TestCentre)
                         .Include(p => p.NextOfKin)
                         .Include(p => p.PortOfEntry)
                         .Include(p => p.PortOfEntry.Enum_PortOfEntry)
                         .Include(p => p.User)
                         .FirstOrDefault(f => f.Id == id);
     
            if (data != null){
                if (testCentreId == data.TestCentreId)
                {
                    return data;
                }
                //unauthorized
                return null;
            }
            return null;
        }

        public void Edit(int id, Patient item, int testCentreId)
        {
           
            var itemToEdit = DB.Patients.Include(p=>p.NextOfKin).Include(p=>p.PortOfEntry).FirstOrDefault(f => f.Id == id);
            if (itemToEdit != null)
            {
                if (testCentreId == itemToEdit.TestCentreId)
                {
                    itemToEdit.Name = item.Name;
                    itemToEdit.Surname = item.Surname;
                    itemToEdit.IdNumber = item.IdNumber;
                    itemToEdit.IdType = item.IdType;
                    itemToEdit.HomeAddress = item.HomeAddress;
                    itemToEdit.PhoneNumber = item.PhoneNumber;
                    itemToEdit.ProvinceId = item.ProvinceId;
                    itemToEdit.NationalityId = item.NationalityId;
                    itemToEdit.Disabled = item.Disabled;
                    itemToEdit.PreviousCountryId = item.PreviousCountryId;
                    itemToEdit.SexId = item.SexId;
                    itemToEdit.PreviousCountryCity = item.PreviousCountryCity;
                    itemToEdit.Occupation = item.Occupation;
                    itemToEdit.DOB = item.DOB;
                    //patient centre cannot be edited
                    //next of kin
                    itemToEdit.NextOfKin.Fullname = item.NextOfKin.Fullname;
                    itemToEdit.NextOfKin.Address = item.NextOfKin.Address;
                    itemToEdit.NextOfKin.Phone = item.NextOfKin.Phone;
                    //port of entry
                    itemToEdit.PortOfEntry.PortOfEntryId = item.PortOfEntry.PortOfEntryId;
                    itemToEdit.PortOfEntry.DateOfArrival = item.PortOfEntry.DateOfArrival;
                    DB.SaveChanges();
                }
            }

        }

        public void Delete(int id,int testCentreId)
        {
            var item = DB.Patients.FirstOrDefault(f => f.Id == id);
                if (item != null)
                {
                    if (testCentreId == item.TestCentreId)
                    {
                        DB.Patients.Remove(item);
                        DB.SaveChanges();
                    }
                      
                }
            
           
        }

        public List<Patient> List(int testCentreId)
        {           
           var data = DB.Patients
                .Include(p => p.Enum_Province)
                .Include(p => p.Enum_NationalityCountry)
                .Include(p => p.Enum_PreviousCountry)
                .Include(p => p.Enum_Sex)
                .Include(p=>p.Enum_IdType)
                .Include(p=>p.TestCentre)
                .Where(p=>p.TestCentreId== testCentreId).ToList();
                return data;
        }
    }

    public class NextOfKinRepository : BaseRepository
    {
        public NextOfKinRepository() : base() { }

        public NextOfKinRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public void Create(NextOfKin item)
        {
            DB.NextOfKins.Add(item);
            DB.SaveChanges();
        }

        public NextOfKin Read(int id)
        {
            return DB.NextOfKins.FirstOrDefault(f => f.Id == id);
        }

        public void Edit(int id, NextOfKin item)
        {
            var itemToEdit = DB.NextOfKins.FirstOrDefault(f => f.Id == id);
            if (itemToEdit != null)
            {
                itemToEdit.Id = item.Id;
                itemToEdit.PatientId = item.PatientId;
                itemToEdit.Fullname = item.Fullname;
                itemToEdit.Address = item.Address;
                itemToEdit.Phone = item.Phone;
            }
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = DB.NextOfKins.FirstOrDefault(f => f.Id == id);
            if (item != null)
            {
                DB.NextOfKins.Remove(item);
                DB.SaveChanges();
            }
        }

        public List<NextOfKin> List()
        {
            return DB.NextOfKins.ToList();
        }
    }

    public class PortOfEntryRepository : BaseRepository
    {
        public PortOfEntryRepository() : base() { }

        public PortOfEntryRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public void Create(PortOfEntry item)
        {
            DB.PortOfEntries.Add(item);
            DB.SaveChanges();
        }

        public PortOfEntry Read(int id)
        {
            return DB.PortOfEntries.FirstOrDefault(f => f.Id == id);
        }

        public void Edit(int id, PortOfEntry item)
        {
            var itemToEdit = DB.PortOfEntries.FirstOrDefault(f => f.Id == id);
            if (itemToEdit != null)
            {
                itemToEdit.Id = item.Id;
                itemToEdit.PatientId = item.PatientId;
                itemToEdit.PortOfEntryId = item.PortOfEntryId;
                itemToEdit.DateOfArrival = item.DateOfArrival;
            }
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = DB.PortOfEntries.FirstOrDefault(f => f.Id == id);
            if (item != null)
            {
                DB.PortOfEntries.Remove(item);
                DB.SaveChanges();
            }
        }

        public List<PortOfEntry> List()
        {
            return DB.PortOfEntries.ToList();
        }
    }

    public class CentreRepository : BaseRepository
    {
        public CentreRepository() : base() { }

        public CentreRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public void Create(Centre item)
        {
            DB.Centres.Add(item);
            DB.SaveChanges();
        }

        public Centre Read(int id)
        {
            return DB.Centres.FirstOrDefault(f => f.Id == id);
        }

        public void Edit(int id, Centre item)
        {
            var itemToEdit = DB.Centres.FirstOrDefault(f => f.Id == id);
            if (itemToEdit != null)
            {
                itemToEdit.Id = item.Id;
                itemToEdit.PatientId = item.PatientId;
                itemToEdit.SharingPatientId = item.SharingPatientId;
                itemToEdit.TestCenterId = item.TestCenterId;
                itemToEdit.Room = item.Room;
                itemToEdit.Floor = item.Floor;
                itemToEdit.Block = item.Block;
                itemToEdit.UtilityCaptureId = item.UtilityCaptureId;
                itemToEdit.Date = item.Date;
                itemToEdit.Blankets = item.Blankets;
                itemToEdit.Cups = item.Cups;
                itemToEdit.Plates = item.Plates;
                itemToEdit.Other = item.Other;
            }
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = DB.Centres.FirstOrDefault(f => f.Id == id);
            if (item != null)
            {
                DB.Centres.Remove(item);
                DB.SaveChanges();
            }
        }

        public List<Centre> List()
        {
            return DB.Centres.ToList();
        }
    }

    public class CaptureHistoryRepository : BaseRepository
    {
        public CaptureHistoryRepository() : base() { }

        public CaptureHistoryRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public void Create(CaptureHistory item)
        {
            DB.CaptureHistories.Add(item);
            DB.SaveChanges();
        }

        public CaptureHistory Read(int id)
        {
            return DB.CaptureHistories.FirstOrDefault(f => f.Id == id);
        }

        public void Edit(int id, CaptureHistory item)
        {
            var itemToEdit = DB.CaptureHistories.FirstOrDefault(f => f.Id == id);
            if (itemToEdit != null)
            {
                itemToEdit.Id = item.Id;
                itemToEdit.PatientId = item.PatientId;
                itemToEdit.LastEditedBy = item.LastEditedBy;
                itemToEdit.LastEditDate = item.LastEditDate;
                itemToEdit.ReasonForEdit = item.ReasonForEdit;
            }
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = DB.CaptureHistories.FirstOrDefault(f => f.Id == id);
            if (item != null)
            {
                DB.CaptureHistories.Remove(item);
                DB.SaveChanges();
            }
        }

        public List<CaptureHistory> List()
        {
            return DB.CaptureHistories.ToList();
        }
    }

    public class CentreHistoryRepository : BaseRepository
    {
        public CentreHistoryRepository() : base() { }

        public CentreHistoryRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public void Create(CentreHistory item)
        {
            DB.CentreHistories.Add(item);
            DB.SaveChanges();
        }

        public CentreHistory Read(int id)
        {
            return DB.CentreHistories.FirstOrDefault(f => f.Id == id);
        }

        public void Edit(int id, CentreHistory item)
        {
            var itemToEdit = DB.CentreHistories.FirstOrDefault(f => f.Id == id);
            if (itemToEdit != null)
            {
                itemToEdit.Id = item.Id;
                itemToEdit.PatientId = item.PatientId;
                itemToEdit.TestCentreId = item.TestCentreId;
                itemToEdit.DateIn = item.DateIn;
                itemToEdit.DateOut = item.DateOut;
                itemToEdit.CovidStatusId = item.CovidStatusId;
                itemToEdit.PatientStatusId = item.PatientStatusId;
                itemToEdit.Notes = item.Notes;
            }
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = DB.CentreHistories.FirstOrDefault(f => f.Id == id);
            if (item != null)
            {
                DB.CentreHistories.Remove(item);
                DB.SaveChanges();
            }
        }

        public List<CentreHistory> List()
        {
            return DB.CentreHistories.ToList();
        }
    }

    public class UserRepository : BaseRepository
    {
        public readonly string super_admin = "super_admin";
        public readonly string national_admin = "national_admin";
        public readonly string provincial_admin = "provincial_admin";
        public readonly string admin = "admin";
        public readonly string capturer = "capturer";

        public UserRepository() : base() { }

        public UserRepository(BaseRepository baseRepo) : base(baseRepo) { }

        public void Create(User user)
        {
            if (user.RoleId != 1)
            {
                PasswordHasher passwordHasher = new PasswordHasher();
                user.Password = passwordHasher.HashPassword(user.Password);
                user.Activated = true;
                DB.Users.Add(user);
                DB.SaveChanges();
            }
           
        }

        public void Edit(int id, User item)
        {
            var itemToEdit = DB.Users.FirstOrDefault(f => f.Id == id);
            if (itemToEdit != null)
            {
                //for the mean time, do not edit, this field
                itemToEdit.TestCentreId = item.TestCentreId;
                //change all except to become a super administrator
                if(item.RoleId!=1)
                itemToEdit.RoleId = item.RoleId;

                if(Find(item.Username) == null)
                {
                    itemToEdit.Username = item.Username;
                }
                if (!string.IsNullOrEmpty(item.Password))
                {
                    PasswordHasher passwordHasher = new PasswordHasher();
                    itemToEdit.Password = passwordHasher.HashPassword(item.Password);
                }

                itemToEdit.Name = item.Name;
                itemToEdit.Surname = item.Surname;
                itemToEdit.Organization = item.Organization;
                itemToEdit.Department = item.Department;
                itemToEdit.Phone = item.Phone;
                itemToEdit.Email = item.Email;
                itemToEdit.Activated = item.Activated;
            }
            DB.SaveChanges();
        }

        public User Read(int id)
        {
            return DB.Users.Include(u=>u.TestCentre).Include(u=>u.Enum_Role).FirstOrDefault(f => f.Id == id);
        }

        public void Delete(int id)
        {
            var item = DB.Users.Include(u=>u.Enum_Role).FirstOrDefault(f => f.Id == id);
            if (item != null)
            {
                if(item.Enum_Role.Value!= super_admin)
                {
                    DB.Users.Remove(item);
                    DB.SaveChanges();
                }
            }
        }

        public List<User> List()
        {
            return DB.Users.Where(u=>u.Enum_Role.Value!=super_admin).ToList();
        }

        public User Find(string username, string password)
        {
            var user = DB.Users.Include(u=>u.Enum_Role).Include(u=>u.TestCentre).FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                PasswordHasher passwordHasher = new PasswordHasher();
                var result = passwordHasher.VerifyHashedPassword(user.Password, password);
                if (result == PasswordVerificationResult.Success)
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

        public User Find(int id)
        {
            return DB.Users.FirstOrDefault(u => u.Id == id);
        }

    }

}
