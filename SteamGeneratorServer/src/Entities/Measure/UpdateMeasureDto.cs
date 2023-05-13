using System.ComponentModel.DataAnnotations;

namespace SteamGeneratorServer.Entities.Measure;

public class UpdateMeasureDto
{
	[Required]
	public string Title { get; }

	[Required]
	public float Value { get; }

	public UpdateMeasureDto(string title, float value)
	{
		Title = title;
		Value = value;
	}
}