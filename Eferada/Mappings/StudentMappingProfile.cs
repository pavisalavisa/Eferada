using AutoMapper;
using Eferada.Data.Model.Entities;
using Eferada.Models.RequestModels;

namespace Eferada.Mappings
{
    public class StudentMappingProfile : Profile
    {
        public override string ProfileName => nameof(StudentMappingProfile);

        public StudentMappingProfile()
        {
            CreateMap<Student, StudentPostRequestModel>()
                .ReverseMap();

            CreateMap<Student, StudentPutRequestModel>()
                .ReverseMap();
        }
    }
}