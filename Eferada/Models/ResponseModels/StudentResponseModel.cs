using System;
using Eferada.Data.Model.Enums;

namespace Eferada.Models.ResponseModels
{
    public class StudentResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AcademicYear { get; set; }
        public string StudentCardCode { get; set; }
        public int CourseId { get; set; }
        public DateTime BirthDateTime { get; set; }
        public DateTime EnrollmentYear { get; set; }
        public StudentStatus StudentStatus { get; set; }
        public string Address { get; set; }// TODO: include Address type in the future
    }
}