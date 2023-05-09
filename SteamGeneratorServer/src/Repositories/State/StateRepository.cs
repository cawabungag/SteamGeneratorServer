using SQLite;
using SteamGeneratorServer.Entities;

namespace DailySpendingBot.Repositories;

public class StateRepository : IStateRepository
{
	private const string TABLE_NAME = "state";
	private readonly SQLiteConnection _sqLite;

	public StateRepository(DatabaseHandler databaseHandler)
	{
		_sqLite = databaseHandler.Db;
	}

	public async Task<IEnumerable<State>> GetStatesAsync()
	{
		var result = _sqLite.Query<State>($"SELECT * FROM {TABLE_NAME}");
		return await Task.FromResult(result);
	}

	public async Task<State?> GetStateAsync(Guid id)
	{
		var result = GetStatesAsync().Result.FirstOrDefault(x => x.Id == id);
		return await Task.FromResult(result);
	}

	public async Task CreateStateAsync(State item)
	{
		_sqLite.Insert(item);
		await Task.CompletedTask;
	}

	public async Task UpdateStateAsync(State item)
	{
		_sqLite.Update(item);
		await Task.CompletedTask;
	}

	public async Task DeleteStateAsync(Guid id)
	{
		_sqLite.Delete<State>(id);
		await Task.CompletedTask;
	}
}