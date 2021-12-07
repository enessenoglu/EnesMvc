using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnesMvc.Models.Manager
{
    public class PersonsDatabaseContext :DbContext
    {
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public PersonsDatabaseContext()
        {
            Database.SetInitializer(new personsDatabaseCreator());
        }
    }
    public class personsDatabaseCreator : CreateDatabaseIfNotExists<PersonsDatabaseContext>
    {
        //InitializeDatabase ==> Database oluşmadan önce yapılması gereken işlemleri bu metot içerisinde yaparak initializeDatabase'i eziyoruz
        public override void InitializeDatabase(PersonsDatabaseContext context)
        {
            base.InitializeDatabase(context);
        }
        //Seed database ==>database oluştuktan sonra eklnemesi gereken işlemleri yapmak için kullanıyoruz.
        protected override void Seed(PersonsDatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Persons per = new Persons();
                per.Name = FakeData.NameData.GetFirstName();
                per.Surname = FakeData.NameData.GetSurname();
                per.Age = FakeData.NumberData.GetNumber(18,99);

                context.Persons.Add(per);

            }
            context.SaveChanges();

            List<Persons> Allpersons = context.Persons.ToList();//select * from tblPersons
            foreach (Persons person in Allpersons)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    Addresses adr = new Addresses();
                    adr.Description = FakeData.PlaceData.GetAddress();
                    adr.City = FakeData.PlaceData.GetCity();
                    adr.Persons = person;
                    context.Addresses.Add(adr);
                }
               
            }
            context.SaveChanges();
        }
    }
}