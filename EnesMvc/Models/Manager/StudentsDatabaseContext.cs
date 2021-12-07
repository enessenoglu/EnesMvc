using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnesMvc.Models.Manager
{
    public class StudentsDatabaseContext:DbContext
    {
      public  DbSet<Students> students { get; set; }
      public  DbSet<Teachers> teachers { get; set; }
        public StudentsDatabaseContext()
        {
            Database.SetInitializer(new StudentDatabaseCreator());
        }
    }
    public class StudentDatabaseCreator : CreateDatabaseIfNotExists<StudentsDatabaseContext>
    {
        public override void InitializeDatabase(StudentsDatabaseContext context)
        {
            base.InitializeDatabase(context);
        }
        protected override void Seed(StudentsDatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Teachers teachers = new Teachers();
                teachers.Name = FakeData.NameData.GetFirstName();
                teachers.Surname = FakeData.NameData.GetSurname();
                teachers.Department = FakeData.NameData.GetCompanyName();
                context.teachers.Add(teachers);
            }
            context.SaveChanges();
            List<Teachers> AllTeachers = context.teachers.ToList();
            foreach (Teachers teacher in AllTeachers)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,20); i++)
                {
                    Students students = new Students();
                    students.Name = FakeData.NameData.GetFirstName();
                    students.Surname = FakeData.NameData.GetSurname();
                    students.Teachers = teacher;
                    context.students.Add(students);

                }

            }
            context.SaveChanges();

        }
    }

}