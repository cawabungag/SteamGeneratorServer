using System.ComponentModel.DataAnnotations;

namespace SteamGeneratorServer.Entities.Measure;

public class CreateMeasureDto
{
	[Required]
	public string Title { get; }

	[Required]
	public float Value { get; }

	public CreateMeasureDto(string title, float value)
	{
		Title = title;
		Value = value;
	}
}