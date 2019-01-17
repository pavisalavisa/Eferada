using Eferada.Data.Model.Entities.Base;

namespace Eferada.Data.Model.Entities
{
    public class Course : BaseNameEntity
    {
        public int DurationInYears { get; set; }
    }
}