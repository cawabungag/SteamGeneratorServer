using Newtonsoft.Json;
using SteamGeneratorServer.Entities.State;

namespace SteamGeneratorServer.Entities;

public class CreateStateDto
{
	[JsonProperty("type")]
	public StateType Type { get; }

	[JsonProperty("status")]
	public StateStatus Status { get; }

	[JsonProperty("duration")]
	public float Duration { get; }

	public CreateStateDto(StateType type, StateStatus status, float duration)
	{
		Type = type;
		Status = status;
		Duration = duration;
	}
}