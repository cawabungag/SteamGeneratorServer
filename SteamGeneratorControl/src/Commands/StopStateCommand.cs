using SteamGeneratorControl.Requests;
using SteamGeneratorServer.Entities.State;
using UpdateStateDto = SteamGeneratorControl.Data.UpdateStateDto;

namespace SteamGeneratorControl.Commands;

public class StopStateCommand : BaseCommand
{
	public override bool IsLoop => false;
	public override string Command => "stop";

	public override async Task<CommandMessage[]> Execute()
	{
		//stop 0000-0000-0000-0000
		var stateRequest = StateRequest.GetInstance();
		var guidInput = Parameters[0];

		if (!Guid.TryParse(guidInput, out var guid))
		{
			Console.WriteLine("Неправильно указан Guid операции");
			return null;
		}

		stateRequest.Put(new UpdateStateDto(StateStatus.Finished, guid), guid);
		return new[] {new CommandMessage($"Остановлена задача", $"{guid} {DateTimeOffset.Now}")};
	}
}