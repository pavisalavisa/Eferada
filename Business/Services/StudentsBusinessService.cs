using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Services.Contracts;
using Eferada.Data.DatabaseContext;
using Eferada.Data.Model.Entities;
using Eferada.Repository;

namespace Business.Services
{
    public class StudentsBusinessService : IStudentBusinessService
    {
        private readonly IEferadaDbContext _dbContext;
        private readonly IRepository<Student> _studentRepository;

        public StudentsBusinessService(IEferadaDbContext dbContext, IRepository<Student> studentRepository)
        {
            _dbContext = dbContext;
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> Get()
        {
            var students = await _studentRepository.GetAsync().ConfigureAwait(false);

            return students;
        }
    }
}