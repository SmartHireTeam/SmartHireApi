using MediatR;
using SmartHire.Model.Response;

namespace SmartHire.Model.Request
{
    public record GetAppUserRequest(int? AppUserId) : IStreamRequest<AppUserDetails>
    {
    }
}
