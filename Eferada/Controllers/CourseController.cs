using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Business.Services.Contracts;
using Eferada.Data.Model.Entities;
using Eferada.Infrastructure;
using Eferada.Models.RequestModels;


namespace Eferada.Controllers
{
    [EferadaRoutePrefix(nameof(CourseController))]
    public class CourseController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ICourseBusinessService _courseBusinessService;

        public CourseController(IMapper mapper, ICourseBusinessService courseBusinessService)
        {
            _mapper = mapper;
            _courseBusinessService = courseBusinessService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var courses = await _courseBusinessService.Get().ConfigureAwait(false);

            return Ok(courses);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri]string name)
        {
            var course = await _courseBusinessService.Get(name).ConfigureAwait(false);

            return Ok(course);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseRequestPostModel request)
        {
            var model = _mapper.Map<Course>(request);
            var course = await _courseBusinessService.Create(model).ConfigureAwait(false);

            return Ok(course);
        }
    }
}