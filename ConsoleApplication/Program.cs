using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.SchoolDb;
using Model;
using Ninject;

namespace ConsoleApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Add student and a new Classroom
            using (var unitOfWork = new UnitOfWork(new SchoolContext()))
            {
                Student student = new Student
                {
                    Classroom = new Classroom { Name = "1A" },
                    DateOfBirth = DateTime.Now,
                    Name = "Dave"
                };

                unitOfWork.Students.Add(student);
                unitOfWork.SaveChanges();
            }

            // ADD 3 Teachers 
            using (var unitOfWork = new UnitOfWork(new SchoolContext()))
            {
                List<Teacher> teachers = new List<Teacher>();

                teachers.Add(new Teacher()
                {
                    Name = "Teacher1"
                });
                teachers.Add(new Teacher()
                {
                    Name = "Teacher2"
                });
                teachers.Add(new Teacher()
                {
                    Name = "Teacher3"
                });

                unitOfWork.Teachers.AddRange(teachers);
                unitOfWork.SaveChanges();
            }

            //// UPDATE Classroom adding Teachers
            ///  THIS METHOD NEEDS TO BE IMPLEMENTED SPECIFICALLY IN THE CLASSROOM REPOSITORY
            //using (var unitOfWork = new UnitOfWork(new SchoolContext()))
            //{
            //    Classroom updatedClassroom = new Classroom
            //    {
            //        Id = 1,
            //        Teachers = new List<Teacher>
            //        {
            //            new Teacher {Id = 3},
            //            new Teacher {Id = 1}
            //        }
            //    };
            //}

            // Add Classroom with existing teachers. 
            // Check implementation of ClassroomsRepository.AddWithExistingTeachers
            using (var unitOfWork = new UnitOfWork(new SchoolContext()))
            {

                unitOfWork.Classrooms.AddWithExistingTeachers(new Classroom
                {
                    Name = "Classroom with existing teachers3",
                    Teachers = new List<Teacher> { new Teacher { Id = 2 }, new Teacher { Id = 3 } }
                });

                unitOfWork.SaveChanges();
            }

            // Add Student with existing classroom
            using (var unitOfWork = new UnitOfWork(new SchoolContext()))
            {
                unitOfWork.Students.AddWithExistingClassroom(new Student { Name = "Fab", ClassId =  1});
                unitOfWork.SaveChanges();
            }
        }
    }
}
