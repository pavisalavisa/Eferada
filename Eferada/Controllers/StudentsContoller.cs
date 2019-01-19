using System.Threading.Tasks;
using System.Web.Http;
using Business.Services.Contracts;
using Eferada.Infrastructure;

namespace Eferada.Controllers
{
    [EferadaRoutePrefix(nameof(StudentsController))]
    public class StudentsController : ApiController
    {
        private readonly IStudentBusinessService _studentsBusinessService;

        public StudentsController(IStudentBusinessService studentsBusinessService)
        {
            _studentsBusinessService = studentsBusinessService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var students = await _studentsBusinessService.Get().ConfigureAwait(true);
            return Ok(students);
        }
    }
}