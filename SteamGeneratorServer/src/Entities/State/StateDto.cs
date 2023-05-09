namespace SteamGeneratorServer.Entities;

public class StateDto
{
	public Guid Id { get; init; }
	public StateType Type { get; init; }
	public StateStatus Status { get; init; }
	public float Duration { get; init; }
	public DateTimeOffset CreatedDate { get; init; }
}