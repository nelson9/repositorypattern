using System;
using Data.SchoolDb.Repositories;

namespace Data.SchoolDb
{
    // This is specific to the application.
    // So it will contain all the entities related to the application
    public interface IUnitOfWork : IDisposable
    {
        IClassroomRepository Classrooms { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }

        int SaveChanges();

        //void Reset();
    }
}
