using System;
using Eferada.Data.Model.Enums;

namespace Eferada.Models.RequestModels
{
    public class StudentPostRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AcademicYear { get; set; }
        public string IdentificationNumber { get; set; }
        public string Course { get; set; }
        public string Subjects { get; set; }
        public DateTime BirthDateTime { get; set; }
        public StudentStatus StudentStatus { get; set; }
    }
}