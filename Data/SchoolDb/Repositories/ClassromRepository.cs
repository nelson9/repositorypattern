using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using Data.BaseClasses;
using Data.Generic;
using Model;

namespace Data.SchoolDb.Repositories
{
    public interface IClassroomRepository : IRepository<Classroom>
    {
        // I can add here methods that are specific to the classroom repository.
        IEnumerable<Classroom> GetClassroomWithTeachers(int id);

        void AddWithExistingTeachers(Classroom entity);
    }

    public class ClassroomRepository : Repository<Classroom>, IClassroomRepository
    {
        public SchoolContext SchoolContext
        {
            get
            {
                return Context as SchoolContext;
            }
        }

        public ClassroomRepository(SchoolContext context) : base(context)
        {
        }

        public IEnumerable<Classroom> GetClassroomWithTeachers(int id)
        {
            return SchoolContext.Classrooms.Include(x => x.Teachers).ToList();
        }

        
        public void AddWithExistingTeachers(Classroom entity)
        {
            // Attacvh to existing teachers.
            foreach (var teacher in entity.Teachers)
            {
                SchoolContext.Teachers.Attach(teacher);
            }

            SchoolContext.Classrooms.Add(entity);
        }
    }
}
