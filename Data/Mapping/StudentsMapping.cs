using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data.Mapping
{
    internal class StudentsMapping : EntityTypeConfiguration<Student>
    {
        public StudentsMapping()
        {
            HasKey(s => s.Id);

            HasRequired(s => s.Classroom)
                .WithMany(c => c.Students)
                .HasForeignKey(x => x.ClassId);

            Property(x => x.ClassId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
