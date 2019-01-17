namespace Eferada.Data.Model.Entities
{
    public class SubjectStudent
    {
        //TODO: make composite key
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Grade { get; set; }
    }
}