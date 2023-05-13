using SteamGeneratorControl.Requests;

namespace SteamGeneratorControl.Commands;

public class ReadMeasureCommand : BaseCommand
{
	private readonly List<CommandMessage> _measuresMessageBuffer = new();
	private DateTimeOffset _lastReadedMeasireTime = DateTimeOffset.MinValue;

	public override bool IsLoop => true;
	public override string Command => "measure";

	public override async Task<CommandMessage[]> Execute()
	{
		_measuresMessageBuffer.Clear();

		if (Parameters != null)
		{
			Console.WriteLine($"В команде {Command} не предусмотрены параметры");
			return null;
		}

		var measures = MeasuresRequest.GetInstance().Get().Result;
		foreach (var measure in measures)
		{
			var measureCreatedDate = measure.CreatedDate;
			if (measureCreatedDate <= _lastReadedMeasireTime)
				continue;

			_measuresMessageBuffer.Add(
				new CommandMessage(measure.Title, measure.Value.ToString("F"), ConsoleColor.Blue));
			_lastReadedMeasireTime = measureCreatedDate;
		}

		return _measuresMessageBuffer.ToArray();
	}
}