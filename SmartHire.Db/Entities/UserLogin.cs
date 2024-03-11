using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHire.Db.Entities
{
    [Table("UserLogin", Schema = "SmartHire")]
    public class UserLogin
    {
        [Column("UserLoginId")]
        public required int UserLoginId { get; set; }

        [Column("AppUserId")]
        public required int AppUserId { get; set;}

        [Column("Password")]
        public required string Password { get; set; }
    }
}
