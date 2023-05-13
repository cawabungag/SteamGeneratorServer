using SteamGeneratorControl.Requests;
using SteamGeneratorServer.Entities.State;
using CreateStateDto = SteamGeneratorServer.Entities.CreateStateDto;

namespace SteamGeneratorControl.Commands;

public class StartStateCommand : BaseCommand
{
	public override bool IsLoop => false;
	public override string Command => "start";

	public override async Task<CommandMessage[]> Execute()
	{
		//start heating 10
		var stateTypeInput = Parameters[0];
		var durationInput = Parameters[1];
		
		var stateType = stateTypeInput.ToStateType();
		if (stateType == StateType.None)
		{
			Console.WriteLine("Неправильно указан тип операции");
			return null;
		}

		if (!float.TryParse(durationInput, out var duration) 
			&& stateType != StateType.Close 
			&& stateType != StateType.Open
			&& stateType != StateType.PluggingIn)
		{
			Console.WriteLine("Неправильно указана длительность операции");
			return null;
		}

		StateRequest.GetInstance().Post(new CreateStateDto(stateType, StateStatus.Queued, duration));
		return new[] {new CommandMessage($"Добавлена задача", $"{stateTypeInput} {DateTimeOffset.Now}")};
	}
}