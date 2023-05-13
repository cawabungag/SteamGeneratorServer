using SQLite;
using SteamGeneratorServer.Database;

namespace SteamGeneratorServer.Repositories.State;

public class StateRepository : IStateRepository
{
	private const string TABLE_NAME = "state";
	private readonly SQLiteConnection _sqLite;

	public StateRepository(DatabaseHandler databaseHandler)
	{
		_sqLite = databaseHandler.Db;
	}

	public async Task<IEnumerable<Entities.State.State>> GetStatesAsync()
	{
		var result = _sqLite.Query<Entities.State.State>($"SELECT * FROM {TABLE_NAME}");
		return await Task.FromResult(result);
	}

	public async Task<Entities.State.State?> GetStateAsync(Guid id)
	{
		var result = GetStatesAsync().Result.FirstOrDefault(x => x.Id == id);
		return await Task.FromResult(result);
	}

	public async Task CreateStateAsync(Entities.State.State item)
	{
		_sqLite.Insert(item);
		await Task.CompletedTask;
	}

	public async Task UpdateStateAsync(Entities.State.State item)
	{
		_sqLite.Update(item);
		await Task.CompletedTask;
	}

	public async Task DeleteStateAsync(Guid id)
	{
		_sqLite.Delete<Entities.State.State>(id);
		await Task.CompletedTask;
	}
}