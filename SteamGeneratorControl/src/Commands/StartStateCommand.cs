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

		var stateType = stateTypeInput.ToStateType();
		if (stateType == StateType.None)
		{
			Console.WriteLine("Неправильно указан тип операции");
			return null;
		}

		if (Parameters.Length == 1
			&& stateType != StateType.Close
			&& stateType != StateType.Open
			&& stateType != StateType.PluggingIn
			&& stateType != StateType.PluggingOut)
			return null;

		float duration = 0;
		if (Parameters.Length > 1)
		{
			var durationInput = Parameters[1];
			if (!float.TryParse(durationInput, out duration)
				&& stateType != StateType.Close
				&& stateType != StateType.Open
				&& stateType != StateType.PluggingIn
				&& stateType != StateType.PluggingOut)
			{
				Console.WriteLine("Неправильно указана длительность операции");
				return null;
			}
		}


		StateRequest.GetInstance().Post(new CreateStateDto(stateType, StateStatus.Queued, duration));
		return new[] {new CommandMessage($"Добавлена задача", $"{stateTypeInput} {DateTimeOffset.Now}")};
	}
}