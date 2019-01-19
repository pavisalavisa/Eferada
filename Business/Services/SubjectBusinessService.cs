using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Services.Contracts;
using Eferada.Data.DatabaseContext;
using Eferada.Data.Model.Entities;
using Eferada.Repository;

namespace Business.Services
{
    public class SubjectBusinessService : ISubjectBusinessService
    {
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IEferadaDbContext _dbContext;

        public async Task<IEnumerable<Subject>> Get()
        {
            var subjects = await _subjectRepository.GetAsync().ConfigureAwait(false);

            return subjects;
        }

        public async Task<Subject> Get(string name)
        {
            var subject = await _subjectRepository.GetFirstOrDefaultAsync(x => x.Name == name).ConfigureAwait(false);
            if (subject == null)
            {
                throw new Exception($"Subject with name {name} does not exist!");
            }

            return subject;
        }

        public Task<Subject> Create(Subject model)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> Update(Subject model)
        {
            throw new NotImplementedException();
        }
    }
}