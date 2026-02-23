using MediaTracker.Domain.Enums;

namespace MediaTracker.Api.Dtos;

public class UpdateMediaEntryRequest
{
    public MediaStatus Status { get; set; }
}