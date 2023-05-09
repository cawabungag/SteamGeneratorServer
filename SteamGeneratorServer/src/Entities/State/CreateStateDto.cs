using System.ComponentModel.DataAnnotations;

namespace SteamGeneratorServer.Entities;

public class CreateStateDto
{
	[Required]
	public StateType Type { get; }

	[Required]
	public StateStatus Status { get; }

	[Required]
	public float Duration { get; }

	public CreateStateDto(StateType type, StateStatus status, float duration)
	{
		Type = type;
		Status = status;
		Duration = duration;
	}
}