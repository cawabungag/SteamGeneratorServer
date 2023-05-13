using SteamGeneratorControl.Requests;

namespace SteamGeneratorControl.Commands;

public class ReadStatesCommand : BaseCommand
{
	private readonly List<CommandMessage> _statesMessageBuffer = new();

	public override bool IsLoop => false;
	public override string Command => "states";

	public override async Task<CommandMessage[]> Execute()
	{
		_statesMessageBuffer.Clear();
		var states = StateRequest.GetInstance().Get().Result;

		if (states == null)
			return null;
		
		foreach (var state in states)
		{
			_statesMessageBuffer.Add(new CommandMessage($"{state.Id}",
				$"{state.Type} {state.Status} {state.Duration:F}"));
		}

		return _statesMessageBuffer.ToArray();
	}
}