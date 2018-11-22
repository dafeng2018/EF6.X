using System.Data.Entity.ModelConfiguration;

namespace Many2Many
{
    internal class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            HasKey(t => t.Id);

        }
    }
}