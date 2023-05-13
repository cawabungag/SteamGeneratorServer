using SteamGeneratorServer.Entities.Measure;
using CreateMeasureDto = FinanceService.Controllers.Entities.Measure.CreateMeasureDto;

namespace SteamGeneratorControl.Requests;

public class MeasuresRequest : BaseRequest<Measure, CreateMeasureDto, UpdateMeasureDto, MeasuresRequest>
{
	protected override string Endpoint => "measures";
}