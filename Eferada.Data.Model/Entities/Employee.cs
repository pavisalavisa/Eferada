using Eferada.Data.Model.Entities.Base;
using Eferada.Data.Model.Entities.Identity;

namespace Eferada.Data.Model.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }// TODO: include Address type in the future

        public ApplicationUser ApplicationUser { get; set; } // TODO: set 1 to 1 relationship http://www.entityframeworktutorial.net/code-first/configure-one-to-one-relationship-in-code-first.aspx
    }
}