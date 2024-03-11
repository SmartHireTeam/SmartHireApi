using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHire.Db.Entities
{
    [Table("JobDescription", Schema = "SmartHire")]
    public class JobDescription
    {
        [Column("RequisitionId")]
        public required int RequisitionId { get; set; }

        [Column("JobCode")]
        public required string JobCode { get; set; }

        [Column("JobDomain")]
        public required string DomainName { get; set; } = string.Empty;

        [Column("FileName")]
        public required string FileName { get; set; }

        [Column("FilePath")]
        public required string FilePath { get; set;}

        [Column("FileFormat")]
        public required string FileFormat { get; set;}

        [Column("UploadedBy")]
        public string? UploadedBy { get; set;}

        [Column("UploadedAt")]
        public DateTime? UploadedAt { get; set; }
        
    }
}
