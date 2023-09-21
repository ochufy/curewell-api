﻿using System;
using System.Collections.Generic;

namespace curewellAPI_DAL.Models
{
    public partial class DoctorSpecialization
    {
        public int DoctorId { get; set; }
        public string SpecializationCode { get; set; } = null!;
        public DateTime SpecializationDate { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Specialization SpecializationCodeNavigation { get; set; } = null!;
    }
}
