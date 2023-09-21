using System;
using System.Collections.Generic;

namespace curewellAPI_DAL.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Surgeries = new HashSet<Surgery>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = null!;

        public virtual ICollection<Surgery> Surgeries { get; set; }
    }
}
