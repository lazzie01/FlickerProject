using DataLayer;
//using System;
using System.ComponentModel.DataAnnotations;

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
        public int TestCentreId { get; set; }
      
        [Required]
        public int RoleId { get; set; }

        [Required]
        public string Username { get; set; }

        //[Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Organization { get; set; }

        public string Department { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Email { get; set; }

        public bool Activated { get; set; }

        public string Token { get; set; }

       // [Required] to help on cyclic
        public TestCentreModel? TestCentre { get; set; }
        public EnumModel Role { get; set; }   
        public UserModel() { }

        public UserModel(User user)
        {
            Id = user.Id;
            TestCentreId = user.TestCentreId.GetValueOrDefault(0);
            RoleId = user.RoleId;
            Username = user.Username;
            Password = user.Password;
            Name = user.Name;
            Surname = user.Surname;
            Organization = user.Organization;
            Department = user.Department;
            Phone = user.Phone;
            Email = user.Email;
            Activated = user.Activated;
            Role = new EnumModel(user.Enum_Role);
            TestCentre = new TestCentreModel(user.TestCentre);
        }

        public User ToModel()
        {
            return new User()
            {
                Id = Id,
                TestCentreId = TestCentreId,
                RoleId = RoleId,
                Username = Username,
                Password = Password,
                Name = Name,
                Surname = Surname,
                Organization = Organization,
                Department = Department,
                Phone = Phone,
                Email = Email,
                Activated = Activated,
                TestCentre = TestCentre==null? null: TestCentre.ToModel()
               // Enum_Role = new Enum_Role() { Key = Role.ToModel().Key, Value = Role.ToModel().Value }
                };
        }
    }

    public class EnumModel
    {
        public int Key { get; set; }

        [Required]
        public string Value { get; set; }

        public EnumModel() { }

        public EnumModel(Enum e) 
        {
            Key = e.Key;
            Value = e.Value;
        }

        public Enum ToModel()
        {
            return new Enum()
            {
                Key = Key,
                Value = Value
            };
        }
    }

    public partial class TestCentreModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public int MenCapacity { get; set; }

        public int WomenCapacity { get; set; }

        public TestCentreModel() { }

        public TestCentreModel(TestCentre item)
        {
            if (item != null)
            {
                Id = item.Id;
                Name = item.Name;
                Address = item.Address;
                Phone = item.Phone;
                MenCapacity = item.MenCapacity;
                WomenCapacity = item.WomenCapacity;
            }
        }

        public TestCentre ToModel()
        {
            return new TestCentre()
            {
                Id = Id,
                Name = Name,
                Address = Address,
                Phone = Phone,
                MenCapacity = MenCapacity,
                WomenCapacity = WomenCapacity
            };
        }
    }

    public partial class CentreModel
    {
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int SharingPatientId { get; set; }

        [Required]
        public int TestCenterId { get; set; }

        [Required]
        public string Room { get; set; }

        [Required]
        public int Floor { get; set; }

        [Required]
        public string Block { get; set; }
        //added
        [Required]
        public int UtilityCaptureId { get; set; }

        [Required]
        public System.DateTime Date { get; set; }

        [Required]
        public int Blankets { get; set; }

        [Required]
        public int Cups { get; set; }

        [Required]
        public int Plates { get; set; }

        public string Other { get; set; }
        //added

        public CentreModel() { }

        public CentreModel(Centre item)
        {
            Id = item.Id;
            PatientId = item.PatientId;
            SharingPatientId = item.SharingPatientId.GetValueOrDefault(0);
            TestCenterId = item.TestCenterId;
            Room = item.Room;
            Floor = item.Floor;
            Block = item.Block;
            UtilityCaptureId = item.UtilityCaptureId.GetValueOrDefault(0);
            Date = item.Date;
            Blankets = item.Blankets;
            Cups = item.Cups;
            Plates = item.Plates;
            Other = item.Other;
        }

        public Centre ToModel()
        {
            return new Centre()
            {
                Id = Id,
                PatientId = PatientId,
                SharingPatientId = SharingPatientId,
                TestCenterId = TestCenterId,
                Room = Room,
                Floor = Floor,
                Block = Block,
                UtilityCaptureId = UtilityCaptureId,
                Date = Date,
                Blankets = Blankets,
                Cups = Cups,
                Plates = Plates,
                Other = Other,
             };
        }


    }

    public partial class CaptureHistoryModel
    {
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int? LastEditedBy { get; set; }

        //must be supplied internally
        public System.DateTime LastEditDate { get; set; }

        [Required]
        public string ReasonForEdit { get; set; }//Why did you edit his/her details, describe fully here

        public CaptureHistoryModel() { }

        public CaptureHistoryModel(CaptureHistory item)
        {
            Id = item.Id;
            PatientId = item.PatientId;
            LastEditedBy = item.LastEditedBy.GetValueOrDefault(0);
            LastEditDate = item.LastEditDate;
            ReasonForEdit = item.ReasonForEdit;
        }

        public CaptureHistory ToModel()
        {
            return new CaptureHistory()
            {
                Id = Id,
                PatientId = PatientId,
                LastEditedBy = LastEditedBy,
                LastEditDate = LastEditDate,
                ReasonForEdit = ReasonForEdit
            };
        }

    }

    public partial class CentreHistoryModel
    {
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int TestCentreId { get; set; }
        //internally
        public System.DateTime DateIn { get; set; }
        //internally
        public System.DateTime DateOut { get; set; }

        [Required]
        public int CovidStatusId { get; set; }

        [Required]
        public int PatientStatusId { get; set; }

        public string Notes { get; set; }

        public CentreHistoryModel() { }

        public CentreHistoryModel(CentreHistory item)
        {
            Id = item.Id;
            PatientId = item.PatientId;
            TestCentreId = item.TestCentreId;
            DateIn = item.DateIn;
            DateOut = item.DateOut.GetValueOrDefault(System.DateTime.MinValue);
            CovidStatusId = item.CovidStatusId;
            PatientStatusId = item.PatientStatusId;
            Notes = item.Notes;
        }

        public CentreHistory ToModel()
        {
            return new CentreHistory()
            {
                Id = Id,
                PatientId = PatientId,
                TestCentreId = TestCentreId,
                DateIn = DateIn,
                DateOut = DateOut,
                CovidStatusId = CovidStatusId,
                PatientStatusId = PatientStatusId,
                Notes = Notes
            };
        }

    }
    ///
    public partial class PatientModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string IdNumber { get; set; }

        [Required]
        public int IdType { get; set; }

        [Required]
        public string HomeAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int ProvinceId { get; set; }

        [Required]
        public int NationalityId { get; set; }

        [Required]
        public bool Disabled { get; set; }

        [Required]
        public System.DateTime DOB { get; set; }

        [Required]
        public int PreviousCountryId { get; set; }

        [Required]
        public int SexId { get; set; }

        [Required]
        public string PreviousCountryCity { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Required]
        public  NextOfKinModel NextOfKin { get; set; }

        [Required]
        public  PortOfEntryModel PortOfEntry { get; set; }

        public int TestCentreId { get; set; }

        public PatientModel() { }

        public PatientModel(Patient item)
        {
            Id = item.Id;
            Name = item.Name;
            Surname = item.Surname;
            IdNumber = item.IdNumber;
            IdType = item.IdType;
            HomeAddress = item.HomeAddress;
            PhoneNumber = item.PhoneNumber;
            ProvinceId = item.ProvinceId;
            NationalityId = item.NationalityId;
            Disabled = item.Disabled;
            DOB = item.DOB;
            PreviousCountryId = item.PreviousCountryId.GetValueOrDefault(0);
            SexId = item.SexId;
            PreviousCountryCity = item.PreviousCountryCity;
            Occupation = item.Occupation;
            TestCentreId = item.TestCentreId.GetValueOrDefault(0);
            NextOfKin = new NextOfKinModel(item.NextOfKin);
            PortOfEntry = new PortOfEntryModel(item.PortOfEntry);
        }

        public Patient ToModel()
        {
            return new Patient()
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                IdNumber = IdNumber,
                IdType = IdType,
                HomeAddress = HomeAddress,
                PhoneNumber = PhoneNumber,
                ProvinceId = ProvinceId,
                NationalityId = NationalityId,
                Disabled = Disabled,
                DOB = DOB,
                PreviousCountryId = PreviousCountryId,
                SexId = SexId,
                PreviousCountryCity = PreviousCountryCity,
                Occupation = Occupation,
                TestCentreId = TestCentreId,
                NextOfKin = NextOfKin.ToModel(),
                PortOfEntry = PortOfEntry.ToModel()
            };
        }

    }

    public partial class NextOfKinModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public NextOfKinModel() { }

        public NextOfKinModel(NextOfKin item)
        {
            Id = item.Id;
            PatientId = item.PatientId;
            Fullname = item.Fullname;
            Address = item.Address;
            Phone = item.Phone;
        }

        public NextOfKin ToModel()
        {
            return new NextOfKin()
            {
                Id = Id,
                PatientId = PatientId,
                Fullname = Fullname,
                Address = Address,
                Phone = Phone
            };
        }

    }

    public partial class PortOfEntryModel
    {

        public int Id { get; set; }

        public int PatientId { get; set; }

        [Required]
        public int PortOfEntryId { get; set; }

        [Required]
        public System.DateTime DateOfArrival { get; set; }

        public PortOfEntryModel() { }

        public PortOfEntryModel(PortOfEntry item)
        {
            Id = item.Id;
            PatientId = item.PatientId;
            PortOfEntryId = item.PortOfEntryId;
            DateOfArrival = item.DateOfArrival;
        }

        public PortOfEntry ToModel()
        {
            return new PortOfEntry()
            {
                Id = Id,
                PatientId = PatientId,
                PortOfEntryId = PortOfEntryId,
                DateOfArrival = DateOfArrival
            };
        }

    }
}
