using System.Collections.Generic;
using System.Threading.Tasks;
using Eferada.Data.Model.Entities;

namespace Business.Services.Contracts
{
    public interface ICourseBusinessService : IBusinessServiceMarker
    {
        Task<IEnumerable<Course>> Get();
        Task<Course> Get(string name);
        Task<Course> Create(Course model);
    }
}
