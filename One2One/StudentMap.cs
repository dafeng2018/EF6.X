using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One2One
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            //Contacts.ID = Students.ID,Contacts.ID即是主键又是外键
            //HasOptional(x => x.Contact).WithRequired(x => x.Student);
            //Contacts.ID/Students.ID自增，Contacts.Student_Id是Students.ID外键，不可为空
            //HasOptional(x => x.Contact).WithOptionalPrincipal(x => x.Student);
            //Contacts.ID/Students.ID自增,Students.Contact_ID 不可为空，是Contacts.ID外键
            HasOptional(x => x.Contact).WithOptionalDependent(x => x.Student);
         }
    }
}
