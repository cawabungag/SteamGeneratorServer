namespace SteamGeneratorServer.Repositories.Measure;

public interface IMeasureRepository
{
	Task<IEnumerable<Entities.Measure.Measure>> GetMeasuresAsync();
	Task<Entities.Measure.Measure?> GetMeasureAsync(Guid id);
	Task CreateMeasureAsync(Entities.Measure.Measure item);
	Task UpdateMeasureAsync(Entities.Measure.Measure item);
	Task DeleteMeasureAsync(Guid id);
}