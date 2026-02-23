using MediaTracker.Domain.Enums;

namespace MediaTracker.Api.Dtos;

public class CreateMediaEntryRequest
{
    public Guid UserId { get; set; }
    public Guid MediaId { get; set; }
    public MediaStatus Status { get; set; }
}