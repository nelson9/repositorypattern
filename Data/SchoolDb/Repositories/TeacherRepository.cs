using System.Data.Entity;
using Data.BaseClasses;
using Data.Generic;
using Model;

namespace Data.SchoolDb.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {

    }

    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext context) : base(context)
        {
        }

        public SchoolContext SchoolContext
        {
            get
            {
                return Context as SchoolContext;
            }
        }
    }
}
