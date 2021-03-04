using System;
namespace FindDoc.Data.Entity.UserProfile.Documents
{
    public class SecureDocuments
    {
        public string Id { get; set; }

        public string Image { get; set; }

        public string DocumentName { get; set; }

        public string DocumentId { get; set; }

        public bool IsApproved { get; set; }
    }
}
