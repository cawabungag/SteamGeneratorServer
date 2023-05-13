using Newtonsoft.Json;
using SteamGeneratorServer.Entities.State;

namespace SteamGeneratorControl.Data;

public class UpdateStateDto
{
	[JsonProperty("id")]
	public Guid Id { get; private set; }

	[JsonProperty("status")]
	public StateStatus Status { get; }

	public UpdateStateDto(StateStatus status, Guid id)
	{
		Status = status;
		Id = id;
	}
}