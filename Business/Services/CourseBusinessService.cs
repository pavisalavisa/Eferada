using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Services.Contracts;
using Eferada.Data.Model.Entities;

namespace Business.Services
{
    public class CourseBusinessService : ICourseBusinessService
    {
        public Task<IEnumerable<Course>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Course> Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<Course> Create(Course model)
        {
            throw new System.NotImplementedException();
        }
    }
}
