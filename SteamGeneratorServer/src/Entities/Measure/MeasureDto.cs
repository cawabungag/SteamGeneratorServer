namespace SteamGeneratorServer.Entities.Measure;

public class MeasureDto
{
	public Guid Id { get; init; }
	public string Title { get; init; }
	public float Value { get; init; }
	public DateTimeOffset CreatedDate { get; init; }
}