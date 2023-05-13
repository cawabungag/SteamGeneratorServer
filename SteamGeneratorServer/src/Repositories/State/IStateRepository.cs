namespace SteamGeneratorServer.Repositories.State;

public interface IStateRepository
{
	Task<IEnumerable<Entities.State.State>> GetStatesAsync();
	Task<Entities.State.State?> GetStateAsync(Guid id);
	Task CreateStateAsync(Entities.State.State item);
	Task UpdateStateAsync(Entities.State.State item);
	Task DeleteStateAsync(Guid id);
}