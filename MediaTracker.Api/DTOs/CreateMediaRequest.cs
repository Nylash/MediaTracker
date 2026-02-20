namespace MediaTracker.Api.Dtos;

public class CreateMediaRequest
{
    public string Title { get; set; } = string.Empty;
    public int Category { get; set; }
}