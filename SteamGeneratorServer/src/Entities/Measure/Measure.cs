using SQLite;

namespace FinanceService.Controllers.Entities.Measure;

public record Measure
{
	[PrimaryKey, AutoIncrement]
	[Column("id")]
	public Guid Id { get; init; }

	[Column("title")]
	public string Title { get; init; }

	[Column("value")]
	public float Value { get; init; }

	[Column("created_date")]
	public DateTimeOffset CreatedDate { get; init; }
}