using SQLite;

namespace SteamGeneratorServer.Entities.State;

public record State
{
	[PrimaryKey, AutoIncrement]
	[Column("id")]
	public Guid Id { get; init; }

	[Column("type")]
	public StateType Type { get; init; }

	[Column("status")]
	public StateStatus Status { get; set; }

	[Column("duration")]
	public float Duration { get; init; }

	[Column("created_date")]
	public DateTimeOffset CreatedDate { get; init; }
}

public enum StateType
{
	None = -1,
	Heating,
	Maintenance,
	Сooling
}

public enum StateStatus
{
	Queued,
	InProgress,
	Finished,
	SteamOpening
}