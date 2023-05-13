using Newtonsoft.Json;

namespace SteamGeneratorControl.Data;

public class Measure
{
	[JsonProperty("id")]
	public Guid Id { get; private set; }

	[JsonProperty("title")]
	public string Title { get; private set; }

	[JsonProperty("value")]
	public int Value { get; private set; }

	[JsonProperty("createdDate")]
	public DateTimeOffset CreateDate { get; private set; }
}