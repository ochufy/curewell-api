using curewellAPI_DAL.Models;

namespace curewellAPI_DAL.Contracts
{
  public interface ICureWellRepository
  {
    bool AddDoctor(Doctor dObj);
    List<Doctor>? GetAllDoctors();
    List<Specialization>? GetAllSpecializations();
    List<Surgery>? GetAllSurgeryTypeForToday();
    //List<DoctorSpecialization> GetDoctorsBySpecialization(string specializationCode);
    bool UpdateDoctorDetails(Doctor dObj);
    bool UpdateSurgery(Surgery sObj);
    bool DeleteDoctor(int doctorID);
  }
}
