using System;
namespace FindDoc.Data.Entity.UserProfile.Documents
{
    public class CerificationDocuments
    {
        public string Id { get; set; }

        public string Direction { get; set; }

        public string Result { get; set; }

        public string CityOfStudying { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
