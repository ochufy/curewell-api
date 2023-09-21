using curewellAPI_DAL.Contracts;
using curewellAPI_DAL.Data;
using curewellAPI_DAL.Models;

namespace curewellAPI_DAL.Repositories
{
    public class CureWellRepository : ICureWellRepository
    {
        private readonly CureWellDBContext context;

        public CureWellRepository(CureWellDBContext context)
        {
            this.context = context;
        }

        public bool AddDoctor(Doctor dObj)
        {
            try
            {
                context.Doctors.Add(dObj);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteDoctor(int doctorID)
        {
            var doctor = context.Doctors.FirstOrDefault(d => d.DoctorId == doctorID);

            if (doctor != null)
            {
                context.Doctors.Remove(doctor);
                context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public List<Doctor>? GetAllDoctors()
        {
            try
            {
                return context.Doctors.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Specialization>? GetAllSpecializations()
        {
            try
            {
                return context.Specializations.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Surgery>? GetAllSurgeryTypeForToday()
        {
            try
            {
                return context.Surgeries.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public List<DoctorSpecialization> GetDoctorsBySpecialization(string specializationCode)
        //{
        //  throw new NotImplementedException();
        //}

        public bool UpdateDoctorDetails(Doctor dObj)
        {
            try
            {
                context.Doctors.Update(dObj);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateSurgery(Surgery sObj)
        {
            try
            {
                context.Surgeries.Update(sObj);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
