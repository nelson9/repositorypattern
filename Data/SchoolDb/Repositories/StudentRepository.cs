using System;
using System.Data.Entity;
using Data.BaseClasses;
using Data.Generic;
using Model;

namespace Data.SchoolDb.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        void AddWithExistingClassroom(Student student);
    }

    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }

        public SchoolContext SchoolContext
        {
            get
            {
                return Context as SchoolContext;
            }
        }

        public void AddWithExistingClassroom(Student student)
        {
            // Attach to existing classroom.
            student.Classroom = new Classroom { Id = student.ClassId };
            SchoolContext.Classrooms.Attach(student.Classroom);

            SchoolContext.Students.Add(student);
        }
    }
}
