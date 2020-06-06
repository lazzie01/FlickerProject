using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{

    public partial class Enum
    {
        [Key]
        public int Key { get; set; }

        public string Value { get; set; }
    }
    
    public partial class Enum_Organization : Enum 
    {
        public Enum_Organization() { }
        
        public Enum_Organization(Enum e) 
        {
            Key = e.Key;
            Value = e.Value;    
        }

        public Enum ToBase()
        {
            return new Enum()
            {
                Key = Key,
                Value = Value
            };
        }
    }

    public partial class Enum_PortOfEntry : Enum
    {
        public Enum_PortOfEntry() { }

        public Enum_PortOfEntry(Enum e)
        {
            Key = e.Key;
            Value = e.Value;
        }
    }

    public partial class Enum_Department : Enum 
    {
        public Enum_Department() { }

        public Enum_Department(Enum e)
        {
            Key = e.Key;
            Value = e.Value;
        }
    }
    
    public partial class Enum_Role : Enum 
    {
        public Enum_Role() { }

        public Enum_Role(Enum e)
        {
            Key = e.Key;
            Value = e.Value;
        }
    }

    public partial class Enum_IdType : Enum 
    {
        public Enum_IdType() { }

        public Enum_IdType(Enum e)
        {
            Key = e.Key;
            Value = e.Value;
        }
    }

    public partial class Enum_Province : Enum 
    {
        public Enum_Province() { }

        public Enum_Province(Enum e)
        {
            Key = e.Key;
            Value = e.Value;
        }
    }

    public partial class Enum_Country : Enum 
    {
        public Enum_Country() { }

        public Enum_Country(Enum e)
        {
            Key = e.Key;
            Value = e.Value;
        }
    }

    public partial class Enum_CovidStatus : Enum 
    {
        public Enum_CovidStatus() { }

        public Enum_CovidStatus(Enum e)
        {
            Key = e.Key;
            Value = e.Value;
        }
    }

    public partial class Enum_HIVStatus : Enum 
    {
        public Enum_HIVStatus() { }

        public Enum_HIVStatus(Enum e)
        {
            Key = e.Key;
            Value = e.Value;
        }
    }

    public partial class Enum_PatientStatus : Enum 
    {
        public Enum_PatientStatus() { }

        public Enum_PatientStatus(Enum e)
        {
            Key = e.Key;
            Value = e.Value;
        }
    }

    public partial class Enum_Sex : Enum 
    {
        public Enum_Sex() { }

        public Enum_Sex(Enum e)
        {
            Key = e.Key;
            Value = e.Value;
        }
    }

    public partial class Enum_Town : Enum
    {
        public Enum_Town() { }

        public Enum_Town (Enum e)
        {
            Key = e.Key;
            Value = e.Value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class TestCentre
    {
        public TestCentre()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public int MenCapacity { get; set; }

        public int WomenCapacity { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }

    public partial class Centre
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [ForeignKey("SharingPatient")]
        public int? SharingPatientId { get; set; }

        [ForeignKey("TestCentre")]
        public int TestCenterId { get; set; }

        public string Room { get; set; }

        public int Floor { get; set; }

        public string Block { get; set; }

        [ForeignKey("User")]
        public int? UtilityCaptureId { get; set; }

        public DateTime Date { get; set; }

        public int Blankets { get; set; }

        public int Cups { get; set; }

        public int Plates { get; set; }

        public string Other { get; set; }

        public virtual User User { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Patient SharingPatient { get; set; }

        public virtual TestCentre TestCentre { get; set; }

    }

    public partial class CaptureHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [ForeignKey("User")]
        public int? LastEditedBy { get; set; }

        public DateTime LastEditDate { get; set; }

        public string ReasonForEdit { get; set; }//Why did you edit his/her details, describe fully here

        public virtual Patient Patient { get; set; }

        public virtual User User { get; set; }
    }

    public partial class CentreHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [ForeignKey("TestCentre")]
        public int TestCentreId { get; set; }

        public DateTime DateIn { get; set; }

        public DateTime? DateOut { get; set; }

        [ForeignKey("Enum_CovidStatus")]
        public int CovidStatusId { get; set; }

        [ForeignKey("Enum_PatientStatus")]
        public int PatientStatusId { get; set; }

        public string Notes { get; set; }

        public virtual Enum_PatientStatus Enum_PatientStatus { get; set; }

        public virtual Enum_CovidStatus Enum_CovidStatus { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual TestCentre TestCentre { get; set; }

    }
    
    public partial class User
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TestCentre")]
        public int? TestCentreId { get; set; }

        [ForeignKey("Enum_Role")]
        [Required]
        public int RoleId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Organization { get; set; }

        public string Department { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        [Required]
        public bool Activated { get; set; }

        public virtual TestCentre? TestCentre { get; set; }

        public virtual Enum_Role Enum_Role { get; set; }
    }

    public partial class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string IdNumber { get; set; }

        [Required]
        [ForeignKey("Enum_IdType")]
        public int IdType { get; set; }

        [Required]
        public string HomeAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [ForeignKey("Enum_Province")]
        public int ProvinceId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int CapturerId { get; set; }

        public DateTime CaptureDate { get; set; }

        public DateTime DOB { get; set; }

        public bool Disabled { get; set; }

        [Required]
        [ForeignKey("Enum_Sex")]
        public int SexId { get; set; }

        [Required]
        public string PreviousCountryCity { get; set; }

        [Required]
        public string Occupation { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Enum_NationalityCountry")]
        public int NationalityId { get; set; }

        [ForeignKey("Enum_PreviousCountry")]
        public int? PreviousCountryId { get; set; }

        [ForeignKey("TestCentre")]
        public int? TestCentreId { get; set; }


        public virtual Enum_Country Enum_NationalityCountry { get; set; }
       
        public virtual Enum_Country Enum_PreviousCountry { get; set; }

        public virtual Enum_IdType Enum_IdType { get; set; }

        public virtual Enum_Province Enum_Province { get; set; }

        public virtual Enum_Sex Enum_Sex { get; set; }

        public virtual NextOfKin NextOfKin { get; set; }

        public virtual PortOfEntry PortOfEntry { get; set; }

        public virtual TestCentre TestCentre { get; set; }

    }

    public partial class NextOfKin
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public string Fullname { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public virtual Patient Patient { get; set; }
    }

    public partial class PortOfEntry
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [ForeignKey("Enum_PortOfEntry")]
        public int PortOfEntryId { get; set; }

        public DateTime DateOfArrival { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Enum_PortOfEntry Enum_PortOfEntry { get; set; }


    }
}
