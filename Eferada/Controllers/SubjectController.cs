using System.Web.Http;
using AutoMapper;
using Business.Services.Contracts;
using Eferada.Infrastructure;

namespace Eferada.Controllers
{
    [EferadaRoutePrefix(nameof(SubjectController))]
    public class SubjectController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISubjectBusinessService _subjectBusinessService;

        public SubjectController(IMapper mapper, ISubjectBusinessService subjectBusinessService)
        {
            _mapper = mapper;
            _subjectBusinessService = subjectBusinessService;
        }
    }
}