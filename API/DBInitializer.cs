using System.Collections.Generic;
using API.Services;
using BusinessLayer;
using DataLayer;
namespace API
{
    public class DBInitializer
    {
        private ApplicationDbContext dbContext;
        public DBInitializer(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Seed()
        {
            //seed initial user & Enum_Roles
            var roles = new List<Enum_Role>()
                    {
                    new Enum_Role(){ Value="super_admin" },
                    new Enum_Role(){ Value="national_admin" },
                    new Enum_Role(){ Value="provincial_admin" },
                    new Enum_Role(){ Value="admin" },
                    new Enum_Role(){ Value="capturer" }
                   };
            User seedUser = new User()
            {
                Enum_Role = roles[0],
                Username = "munetsilazzie@gmail.com",
                Password = "AEL6WhhKQ8iB2hfcCXwX46H1k0Kr92Kq/Nvy6PU6pCvfJjHDXazy+XgjPxpKFLYLKg==",
                Name = "lazarus",
                Surname = "munetsi",
                Organization = "The Code Master",
                Phone = "0775449422",
                Department = "Software Development",
                Email = "munetsilazzie@gmail.com",
                Activated = true
            };
            dbContext.Enum_Roles.AddRange(roles);
            dbContext.Users.Add(seedUser);
            //seed Test Centres
            var testCentres = new List<TestCentre>()
                    {
                    new TestCentre(){ Name="Belvedere Quarantine" },
                    new TestCentre(){ Name="Beitbridge Hotel Quarantine" },
                    new TestCentre(){ Name="Harare Girls High Quarantine" },
                    new TestCentre(){ Name="Harare Poly Quarantine" }
                   };
            dbContext.TestCentres.AddRange(testCentres);
            //seed all other enums
            SeedEnums();
            dbContext.SaveChanges();
        }

        private void SeedEnums()
        {
            var e1 = new List<Enum_Organization>()
                    {
                    new Enum_Organization(){ Value="Ministry of Health & Child Care" },
                    new Enum_Organization(){ Value="Ministry of Social Welfare" },
                    new Enum_Organization(){ Value="Unknown" }
                   };
            dbContext.Enum_Organizations.AddRange(e1);

            var e2 = new List<Enum_Department>()
                    {
                    new Enum_Department(){ Value="Logistics" },
                    new Enum_Department(){ Value="Health" },
                    new Enum_Department(){ Value="Unknown" }
                   };
            dbContext.Enum_Departments.AddRange(e2);
            //Enum_Role initialized already
            var e3 = new List<Enum_IdType>()
                   {
                    new Enum_IdType(){ Value="Zimbabwe Id" },
                    new Enum_IdType(){ Value="Zimbabwe Passport" },
                    new Enum_IdType(){ Value="Unknown" }
                   };
            dbContext.Enum_IdTypes.AddRange(e3);

            var e4 = new List<Enum_Province>()
                   {
                    new Enum_Province(){ Value="Harare" },
                    new Enum_Province(){ Value="Bulawayo" },
                    new Enum_Province(){ Value="Unknown" }
                   };
            dbContext.Enum_Provinces.AddRange(e4);

            var e5 = new List<Enum_Country>()
                   {
                    new Enum_Country(){ Value="Zimbabwe" },
                    new Enum_Country(){ Value="South Africa" },
                    new Enum_Country(){ Value="Unknown" }
                   };
            dbContext.Enum_Countries.AddRange(e5);

            var e6 = new List<Enum_PortOfEntry>()
                   {
                    new Enum_PortOfEntry(){ Value="Beitbridge" },
                    new Enum_PortOfEntry(){ Value="Robert Mugabe International Airport" },
                    new Enum_PortOfEntry(){ Value="Unknown" }
                   };
            dbContext.Enum_PortOfEntries.AddRange(e6);

            var e7 = new List<Enum_CovidStatus>()
                   {
                    new Enum_CovidStatus(){ Value="Negative" },
                    new Enum_CovidStatus(){ Value="Positive" },
                    new Enum_CovidStatus(){ Value="Unknown" }
                   };
            dbContext.Enum_CovidStatuses.AddRange(e7);

            var e8 = new List<Enum_HIVStatus>()
                   {
                    new Enum_HIVStatus(){ Value="Negative" },
                    new Enum_HIVStatus(){ Value="Positive" },
                    new Enum_HIVStatus(){ Value="Unknown" }
                   };
            dbContext.Enum_HIVStatuses.AddRange(e8);

            var e9 = new List<Enum_PatientStatus>()
                   {
                    new Enum_PatientStatus(){ Value="In Quarantine" },
                    new Enum_PatientStatus(){ Value="Discharged" },
                    new Enum_PatientStatus(){ Value="Unknown" }
                   };
            dbContext.Enum_PatientStatuses.AddRange(e9);

            var e10 = new List<Enum_Sex>()
                   {
                    new Enum_Sex(){ Value="Male" },
                    new Enum_Sex(){ Value="Female" },
                    new Enum_Sex(){ Value="Unknown" }
                   };
            dbContext.Enum_Sexes.AddRange(e10);

            var e11 = new List<Enum_Town>()
                   {
                    new Enum_Town(){ Value="Harare" },
                    new Enum_Town(){ Value="Bulawayo" },
                    new Enum_Town(){ Value="Unknown" }
                   };
            dbContext.Enum_Towns.AddRange(e11);
        }
    }
}
