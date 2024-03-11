
namespace SmartHire.Model.Response
{
    public class AppUserDetails
    {
        public required int AppUserId { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public required string Gender { get; set; }
        public string? Email { get; set; } = string.Empty;
        public int? PhoneNumber { get; set; }
        public bool Status { get; set; } = false;
        public string? Password { get; set; }= string.Empty;
    }
}
