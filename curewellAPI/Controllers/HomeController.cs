using AutoMapper;
using curewellAPI_DAL.Contracts;
using curewellAPI_DAL.DTOs;
using curewellAPI_DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace curewellAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICureWellRepository _curewellRepository;
        private readonly IMapper _mapper;

        public HomeController(ICureWellRepository curewellRepository, IMapper mapper)
        {
            _curewellRepository = curewellRepository;
            _mapper = mapper;
        }

        [HttpGet("doctors")]
        public IActionResult GetDoctors()
        {
            var data = _curewellRepository.GetAllDoctors();
            var doctors = _mapper.Map<List<DoctorDto>>(data);
            return Ok(doctors);
        }

        [HttpGet("specializations")]
        public IActionResult GetSpecializations()
        {
            var data = _curewellRepository.GetAllSpecializations();
            var specializations = _mapper.Map<List<SpecializationDto>>(data);
            return Ok(specializations);
        }

        [HttpGet("surgeries")]
        public IActionResult GetAllSurgeryTypeForToday()
        {
            var data = _curewellRepository.GetAllSurgeryTypeForToday();
            var surgeries = _mapper.Map<List<SurgeryDto>>(data);

            return Ok(surgeries);
        }

        [HttpPost("add-doctor")]
        public bool AddDoctor([FromBody] DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);

            if (doctor == null)
            {
                return false;
            }

            bool isDoctorAdded = _curewellRepository.AddDoctor(doctor);

            if (isDoctorAdded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPut("update-doctor")]
        public bool UpdateDoctorDetails([FromBody] DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);

            if (doctor == null)
            {
                return false;
            }

            bool isDoctorUpdated = _curewellRepository.UpdateDoctorDetails(doctor);

            if (isDoctorUpdated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPut("update-surgery")]
        public bool UpdateSurgery([FromBody] SurgeryDto surgeryDto)
        {
            var surgery = _mapper.Map<Surgery>(surgeryDto);

            if (surgery == null)
            {
                return false;
            }

            bool isSurgeryUpdated = _curewellRepository.UpdateSurgery(surgery);

            if (isSurgeryUpdated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpDelete("doctors/{doctorId}")]
        public bool DeleteDoctor([FromRoute] int doctorId)
        {
            bool isDoctorDeleted = _curewellRepository.DeleteDoctor(doctorId);

            if (isDoctorDeleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
