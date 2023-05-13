using System.ComponentModel.DataAnnotations;

namespace SteamGeneratorServer.Entities.State;

public class UpdateStateDto
{
	[Required]
	public StateType Type { get; }

	[Required]
	public StateStatus Status { get; }

	[Required]
	public float Duration { get; }

	public UpdateStateDto(StateType type, StateStatus status, float duration)
	{
		Type = type;
		Status = status;
		Duration = duration;
	}
}