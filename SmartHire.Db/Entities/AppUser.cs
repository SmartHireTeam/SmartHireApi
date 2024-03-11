using System.ComponentModel.DataAnnotations.Schema;


namespace SmartHire.Db.Entities
{
    [Table("AppUser", Schema = "SmartHire")]
    public class AppUser
    {
        [Column("AppUserId")]
        public required int AppUserId { get; set; }

        [Column("FirstName")]
        public required string FirstName { get; set; }

        [Column("MiddleName")]
        public string? MiddleName { get; set;}=string.Empty;

        [Column("LastName")]
        public required string LastName { get; set; } = string.Empty;

        [Column("Gender")]
        public required string Gender { get; set; }

        [Column("Email")]
        public string? Email { get; set; }=string.Empty;

        [Column("Phone")]
        public int? PhoneNumber { get; set; }

        [Column("Status")]
        public required bool Status { get; set;}=false;
    }
}
