using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Business.Services.Contracts;
using Eferada.Data.Model.Entities;
using Eferada.Infrastructure;
using Eferada.Models.RequestModels;
using Eferada.Models.ResponseModels;

namespace Eferada.Controllers
{
    [EferadaRoutePrefix(nameof(StudentsController))]
    public class StudentsController : ApiController
    {
        private readonly IStudentBusinessService _studentsBusinessService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentBusinessService studentsBusinessService, IMapper mapper)
        {
            _studentsBusinessService = studentsBusinessService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var students = await _studentsBusinessService.Get().ConfigureAwait(true);
            return Ok(students);
        }

        [HttpGet]
        [Route("{studentCardCode}")]
        public async Task<IHttpActionResult> Get([FromUri] string studentCardCode)
        {
            var student = await _studentsBusinessService.Get(studentCardCode).ConfigureAwait(true);
            return Ok(student);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(StudentPostRequestModel request)
        {
            var model = _mapper.Map<Student>(request);

            var student = await _studentsBusinessService.Create(model).ConfigureAwait(false);

            var response = _mapper.Map<StudentResponseModel>(student);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(StudentPutRequestModel request)
        {
            var model = _mapper.Map<Student>(request);

            var student = await _studentsBusinessService.Update(model).ConfigureAwait(false);

            var response = _mapper.Map<StudentResponseModel>(student);

            return Ok(response);
        }
    }
}