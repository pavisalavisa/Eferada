using Eferada.Data.Model.Entities.Base;
using System.Collections.Generic;

namespace Eferada.Data.Model.Entities
{
    public class Subject : BaseNameEntity
    {
        public int ECTSNumber { get; set; }
        public string ProfessorName { get; set; }//Professors are not included in the system for now

        public ICollection<Course> Courses { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}