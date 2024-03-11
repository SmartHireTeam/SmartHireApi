
namespace SmartHire.Model.Response
{
    public class JobDescriptionResponse
    {
        public required int RequisitionId { get; set; }

        public  string? JobCode { get; set; }

        public  string? DomainName { get; set; } 

        public  string? FileName { get; set; }

        public  string? FilePath { get; set; }

        public  string? FileFormat { get; set; }

        public string? UploadedBy { get; set; }

        public DateTime? UploadedAt { get; set; }
    }
}
