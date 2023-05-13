using SQLite;
using SteamGeneratorServer.Database;

namespace SteamGeneratorServer.Repositories.Measure;

public class MeasureRepository : IMeasureRepository
{
	private const string TABLE_NAME = "measure";
	private readonly SQLiteConnection _sqLite;

	public MeasureRepository(DatabaseHandler databaseHandler)
	{
		_sqLite = databaseHandler.Db;
	}

	public async Task<IEnumerable<Entities.Measure.Measure>> GetMeasuresAsync()
	{
		var result = _sqLite.Query<Entities.Measure.Measure>($"SELECT * FROM {TABLE_NAME}");
		return await Task.FromResult(result);
	}

	public async Task<Entities.Measure.Measure?> GetMeasureAsync(Guid id)
	{
		var result = GetMeasuresAsync().Result.FirstOrDefault(x => x.Id == id);
		return await Task.FromResult(result);
	}

	public async Task CreateMeasureAsync(Entities.Measure.Measure item)
	{
		_sqLite.Insert(item);
		await Task.CompletedTask;
	}

	public async Task UpdateMeasureAsync(Entities.Measure.Measure item)
	{
		_sqLite.Update(item);
		await Task.CompletedTask;
	}

	public async Task DeleteMeasureAsync(Guid id)
	{
		_sqLite.Delete<Entities.Measure.Measure>(id);
		await Task.CompletedTask;
	}
}