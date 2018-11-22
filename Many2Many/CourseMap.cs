using System.Data.Entity.ModelConfiguration;

namespace Many2Many
{
    internal class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            HasKey(t => t.Id);
            HasMany(t => t.Students).WithMany(t => t.Courses).Map(t => t.ToTable("CourseStudent").MapLeftKey("StudentId").MapRightKey("CourseId"));
        }
    }
}