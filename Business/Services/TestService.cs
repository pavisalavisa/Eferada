
using Business.Services.Contracts;

namespace Business.Services
{
    public class TestService : ITestService, IBusinessServiceMarker
    {
        public string Speak()
        {
            return "I'm alive.";
        }
    }
}