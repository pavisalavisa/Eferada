using System.Collections.Generic;
using System.Threading.Tasks;
using Eferada.Data.Model.Entities;

namespace Business.Services.Contracts
{
    public interface ISubjectBusinessService : IBusinessServiceMarker
    {
        Task<IEnumerable<Subject>> Get();
        Task<Subject> Get(string name);
        Task<Subject> Create(Subject model);
        Task<Subject> Delete(int id);
        Task<Subject> Update(Subject model);
    }
}
