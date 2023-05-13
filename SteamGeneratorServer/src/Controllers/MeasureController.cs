using Microsoft.AspNetCore.Mvc;
using SteamGeneratorServer.Entities.Measure;
using SteamGeneratorServer.Repositories.Measure;
using SteamGeneratorServer.Utils;

namespace SteamGeneratorServer.Controllers;

[ApiController]
[Route("measures")]
public class MeasureController : ControllerBase
{
	private readonly IMeasureRepository _measuresRepository;

	public MeasureController(IMeasureRepository measuresRepository)
	{
		_measuresRepository = measuresRepository;
	}

	//GET /Measures
	[HttpGet]
	public async Task<IEnumerable<MeasureDto>> GetMeasuresAsync()
	{
		var items = (await _measuresRepository.GetMeasuresAsync())
			.Select(item => item.AsDto());
		return items;
	}

	//GET /Measures/id
	[HttpGet("{id}")]
	public async Task<ActionResult<MeasureDto>> GetMeasureAsync(Guid id)
	{
		var measure = await _measuresRepository.GetMeasureAsync(id);
		if (measure is null)
		{
			return NotFound();
		}

		return measure.AsDto();
	}

	//POST /Measures
	[HttpPost]
	public async Task<ActionResult<MeasureDto>> CreateMeasureAsync(CreateMeasureDto measureDto)
	{
		Measure newMeasure = new()
		{
			Id = Guid.NewGuid(),
			Title = measureDto.Title,
			Value = measureDto.Value,
			CreatedDate = DateTimeOffset.UtcNow
		};
		await _measuresRepository.CreateMeasureAsync(newMeasure);

		return CreatedAtAction("GetMeasure", new {id = newMeasure.Id}, newMeasure.AsDto());
	}

	//PUT /Measures/{id}
	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateMeasure(Guid id, UpdateMeasureDto measureDto)
	{
		var existingMeasure = await _measuresRepository.GetMeasureAsync(id);
		if (existingMeasure is null)
			return NotFound();

		var updatedMeasure = existingMeasure with
		{
			Title = measureDto.Title,
			Value = measureDto.Value,
		};
		await _measuresRepository.UpdateMeasureAsync(updatedMeasure);
		return NoContent();
	}

	//DELETE /Measures/{id}
	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteMeasure(Guid id)
	{
		var existingMeasure = await _measuresRepository.GetMeasureAsync(id);
		if (existingMeasure is null)
			return NotFound();

		await _measuresRepository.DeleteMeasureAsync(id);
		return NoContent();
	}
}