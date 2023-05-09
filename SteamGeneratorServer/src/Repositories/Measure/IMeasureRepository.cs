using FinanceService.Controllers.Entities.Measure;

namespace DailySpendingBot.Repositories;

public interface IMeasureRepository
{
	Task<IEnumerable<Measure>> GetMeasuresAsync();
	Task<Measure?> GetMeasureAsync(Guid id);
	Task CreateMeasureAsync(Measure item);
	Task UpdateMeasureAsync(Measure item);
	Task DeleteMeasureAsync(Guid id);
}