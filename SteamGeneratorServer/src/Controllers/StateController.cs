using DailySpendingBot.Repositories;
using Microsoft.AspNetCore.Mvc;
using SteamGeneratorServer.Entities;

namespace FinanceService.Controllers;

[ApiController]
[Route("states")]
public class StateController : ControllerBase
{
	private readonly IStateRepository _statesRepository;

	public StateController(IStateRepository StatesRepository)
	{
		_statesRepository = StatesRepository;
	}

	//GET /States
	[HttpGet]
	public async Task<IEnumerable<StateDto>> GetStatesAsync()
	{
		var items = (await _statesRepository.GetStatesAsync())
			.Select(item => item.AsDto());
		return items;
	}

	//GET /States/id
	[HttpGet("{id}")]
	public async Task<ActionResult<StateDto>> GetStateAsync(Guid id)
	{
		var State = await _statesRepository.GetStateAsync(id);
		if (State is null)
		{
			return NotFound();
		}

		return State.AsDto();
	}

	//POST /States
	[HttpPost]
	public async Task<ActionResult<StateDto>> CreateStateAsync(CreateStateDto stateDto)
	{
		State newState = new()
		{
			Id = Guid.NewGuid(),
			Type = stateDto.Type,
			Status = stateDto.Status,
			Duration = stateDto.Duration,
			CreatedDate = DateTimeOffset.Now
		};
		await _statesRepository.CreateStateAsync(newState);

		return CreatedAtAction("GetState", new {id = newState.Id}, newState.AsDto());
	}

	//PUT /States/{id}
	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateState(Guid id, UpdateStateDto stateDto)
	{
		var existingState = await _statesRepository.GetStateAsync(id);
		if (existingState is null)
			return NotFound();

		var updatedState = existingState with
		{
			Type = stateDto.Type,
			Status = stateDto.Status,
			Duration = stateDto.Duration,
		};
		await _statesRepository.UpdateStateAsync(updatedState);
		return NoContent();
	}

	//DELETE /States/{id}
	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteState(Guid id)
	{
		var existingState = await _statesRepository.GetStateAsync(id);
		if (existingState is null)
			return NotFound();

		await _statesRepository.DeleteStateAsync(id);
		return NoContent();
	}
}