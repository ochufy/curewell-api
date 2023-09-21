using System;
using System.Collections.Generic;

namespace curewellAPI_DAL.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            Surgeries = new HashSet<Surgery>();
        }

        public string SpecializationCode { get; set; } = null!;
        public string SpecializationName { get; set; } = null!;

        public virtual ICollection<Surgery> Surgeries { get; set; }
    }
}
