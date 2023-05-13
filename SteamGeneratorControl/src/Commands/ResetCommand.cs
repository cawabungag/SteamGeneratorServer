using SteamGeneratorControl.Requests;

namespace SteamGeneratorControl.Commands;

public class ResetCommand : BaseCommand
{
	public override bool IsLoop => false;
	public override string Command => "reset";

	public override async Task<CommandMessage[]> Execute()
	{
		var measures =  MeasuresRequest.GetInstance().Get().Result;
		Console.WriteLine($"{measures.Length}");
		foreach (var measure in measures)
		{
			await MeasuresRequest.GetInstance().Delete(measure.Id);
		}

		var states = StateRequest.GetInstance().Get().Result;
		Console.WriteLine($"{states.Length}");
		foreach (var state in states)
		{
			await StateRequest.GetInstance().Delete(state.Id);
		}

		return new[] {new CommandMessage("Удалены", "все записи")};
	}
}