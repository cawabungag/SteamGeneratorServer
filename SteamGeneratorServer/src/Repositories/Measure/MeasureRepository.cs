using FinanceService.Controllers.Entities.Measure;
using SQLite;

namespace DailySpendingBot.Repositories;

public class MeasureRepository : IMeasureRepository
{
	private const string TABLE_NAME = "Measure";
	private readonly SQLiteConnection _sqLite;

	public MeasureRepository(DatabaseHandler databaseHandler)
	{
		_sqLite = databaseHandler.Db;
	}

	public async Task<IEnumerable<Measure>> GetMeasuresAsync()
	{
		var result = _sqLite.Query<Measure>($"SELECT * FROM {TABLE_NAME}");
		return await Task.FromResult(result);
	}

	public async Task<Measure?> GetMeasureAsync(Guid id)
	{
		var result = GetMeasuresAsync().Result.FirstOrDefault(x => x.Id == id);
		return await Task.FromResult(result);
	}

	public async Task CreateMeasureAsync(Measure item)
	{
		_sqLite.Insert(item);
		await Task.CompletedTask;
	}

	public async Task UpdateMeasureAsync(Measure item)
	{
		_sqLite.Update(item);
		await Task.CompletedTask;
	}

	public async Task DeleteMeasureAsync(Guid id)
	{
		_sqLite.Delete<Measure>(id);
		await Task.CompletedTask;
	}
}