using Data.Generic;
using Data.SchoolDb;
using Data.SchoolDb.Repositories;

namespace Data
{

    public class UnitOfWork : IUnitOfWork
    {
        private SchoolContext _context;

        public IClassroomRepository Classrooms { get; private set; }

        public IStudentRepository Students { get; private set; }

        public ITeacherRepository Teachers { get; private set; }

        public UnitOfWork(SchoolContext context)
        {
            _context = context;
            
            Classrooms = new ClassroomRepository(_context);
            Students = new StudentRepository(_context);
            Teachers = new TeacherRepository(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}