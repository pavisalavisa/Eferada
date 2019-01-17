using Eferada.Data.Model.Entities.Base;
using Eferada.Data.Model.Entities.Identity;
using Eferada.Data.Model.Enums;
using System;

namespace Eferada.Data.Model.Entities
{
    public class Student : BaseEntity
    {
        public int AcademicYear { get; set; }
        public string StudentCardCode { get; set; }
        public int CourseId { get; set; }
        public DateTime BirthDateTime { get; set; }
        public DateTime EnrollmentYear { get; set; }
        public StudentStatus StudentStatus { get; set; }
        public string Address { get; set; }// TODO: include Address type in the future

        public ApplicationUser ApplicationUser { get; set; } // TODO: set 1 to 1 relationship http://www.entityframeworktutorial.net/code-first/configure-one-to-one-relationship-in-code-first.aspx
        public Course Course { get; set; }// TODO: set 1 to many relationship
    }
}