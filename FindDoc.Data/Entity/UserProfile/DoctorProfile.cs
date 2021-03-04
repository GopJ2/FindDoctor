using System;
using System.Collections.Generic;
using FindDoc.Data.Entity.UserProfile.Documents;

namespace FindDoc.Data.Entity.UserProfile
{
    public class DoctorProfile: Profile
    {
        public bool IsApproved { get; set; }

        public string University { get; set; }

        public string Department { get; set; }

        public string Speciality { get; set; }

        public string Hospital { get; set; }

        //todo change degree for russian people
        public string Degree { get; set; }

        public string Experience { get; set; }

        public string PhoneNumber { get; set; }

        public List<CerificationDocuments> Cerifications { get; set; }

        public List<SecureDocuments> SecureDocuments { get; set; }

    }
}
