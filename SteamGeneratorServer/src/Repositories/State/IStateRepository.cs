using SteamGeneratorServer.Entities;

namespace DailySpendingBot.Repositories;

public interface IStateRepository
{
	Task<IEnumerable<State>> GetStatesAsync();
	Task<State?> GetStateAsync(Guid id);
	Task CreateStateAsync(State item);
	Task UpdateStateAsync(State item);
	Task DeleteStateAsync(Guid id);
}