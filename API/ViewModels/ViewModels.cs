using API.Helpers;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public partial class PatientListVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string IdNumber { get; set; }

        public string IdType { get; set; }

        public string HomeAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Province { get; set; }

        public string Nationality { get; set; }

        public bool Disabled { get; set; }

        public string Age { get; set; }

        public string PreviousCountry { get; set; }

        public string Sex { get; set; }

        public string PreviousCountryCity { get; set; }

        public string Occupation { get; set; }

        public string TestCentre { get; set; }

        public PatientListVM() { }

        public PatientListVM(Patient item)
        {
            Id = item.Id;
            Name = item.Name;
            Surname = item.Surname;
            IdNumber = item.IdNumber;
            HomeAddress = item.HomeAddress;
            PhoneNumber = item.PhoneNumber;
            Disabled = item.Disabled;
            Age = Calculate.DateDifferenceInYrs(DateTime.Now, item.DOB).ToString();
            PreviousCountryCity = item.PreviousCountryCity;
            Occupation = item.Occupation;
            Province = item.Enum_Province.Value;
            Nationality = item.Enum_NationalityCountry.Value;
            PreviousCountry = item.Enum_PreviousCountry.Value;
            Sex = item.Enum_Sex.Value;
            IdType = item.Enum_IdType.Value;
            TestCentre = item.TestCentre.Name;
      
        }

    }

    public partial class PatientVM : PatientListVM
    {
        public DateTime CaptureDate { get; set; }

        public string CapturedBy { get; set; }

        public DateTime DOB { get; set; }

        public NextOfKinVM NextOfKin { get; set; }

        public PortOfEntryVM PortOfEntry { get; set; }

        //for edit VM
        public int SexId { get; set; }

        public int IdTypeId { get; set; }

        public int nationalityId { get; set; }

        public int provinceId { get; set; }

        public int previousCountryId { get; set; }

        public int pPortOfEntryId { get; set; }

        public PatientVM():base() { }

        public PatientVM(Patient p) : base(p) 
        {
            CaptureDate = p.CaptureDate;
            CapturedBy = p.User.Username;
            DOB = p.DOB.Date;
            NextOfKin = new NextOfKinVM(p.NextOfKin);
            PortOfEntry = new PortOfEntryVM(p.PortOfEntry);
            //ids for editVM
            SexId = p.Enum_Sex.Key;
            IdTypeId = p.Enum_IdType.Key;
            nationalityId = p.Enum_NationalityCountry.Key;
            provinceId = p.Enum_Province.Key;
            previousCountryId = p.Enum_PreviousCountry.Key;
            pPortOfEntryId = p.PortOfEntry.Enum_PortOfEntry.Key;
        }

    }

    public partial class NextOfKinVM
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string Fullname { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public NextOfKinVM() { }

        public NextOfKinVM(NextOfKin n) 
        {
            Id = n.Id;
            PatientId = n.PatientId;
            Fullname = n.Fullname;
            Address = n.Address;
            Phone = n.Phone;
        }

    }

    public partial class PortOfEntryVM
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int PortOfEntryId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfArrival { get; set; }

        public PortOfEntryVM() { }

        public PortOfEntryVM(PortOfEntry p)
        {
            Id = p.Id;
            PatientId = p.PatientId;
            PortOfEntryId = p.PortOfEntryId;
            DateOfArrival = p.DateOfArrival;
            Name = p.Enum_PortOfEntry.Value;
        }

    }
}
