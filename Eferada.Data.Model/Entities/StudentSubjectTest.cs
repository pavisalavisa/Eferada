namespace Eferada.Data.Model.Entities
{
    public class StudentSubjectTest
    {
        public int Id { get; set; }
        public int SubjectTestId { get; set; }
        public int StudentId { get; set; }
        public bool Participated { get; set; }
        public int Grade { get; set; }

        public virtual Student Student { get; set; }
        public virtual SubjectTest SubjectTest { get; set; }
    }
}