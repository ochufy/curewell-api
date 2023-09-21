using AutoMapper;
using curewellAPI_DAL.DTOs;
using curewellAPI_DAL.Models;

namespace curewellAPI_DAL.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SurgeryDto, Surgery>();
            CreateMap<Surgery, SurgeryDto>();
            CreateMap<DoctorDto, Doctor>();
            CreateMap<Doctor, DoctorDto>();
            CreateMap<Specialization, SpecializationDto>();
        }
    }
}
