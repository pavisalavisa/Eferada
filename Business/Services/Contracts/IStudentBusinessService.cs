using System.Collections.Generic;
using System.Threading.Tasks;
using Eferada.Data.Model.Entities;

namespace Business.Services.Contracts
{
    public interface IStudentBusinessService : IBusinessServiceMarker
    {
        Task<IEnumerable<Student>> Get();
    }
}
