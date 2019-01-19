using Eferada.Data.Model.Entities.Base;
using System.Collections.Generic;

namespace Eferada.Data.Model.Entities
{
    public class Course : BaseNameEntity
    {
        public int DurationInYears { get; set; }

        public ICollection<Student> EnrolledStudents{ get; set; }
        public ICollection<Subject> Subjects { get; set; }
   }
}