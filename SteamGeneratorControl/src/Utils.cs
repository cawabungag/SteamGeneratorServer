using SteamGeneratorServer.Entities.State;

namespace SteamGeneratorControl;

public static class Utils
{
	public const string URL = "https://localhost:7146/";
	
	public static StateType ToStateType(this string stateTypeInput)
	{
		var stateType = StateType.None;
		switch (stateTypeInput)
		{
			case "heating":
				stateType = StateType.Heating;
				break;

			case "maintenance":
				stateType = StateType.Maintenance;
				break;

			default:
				Console.WriteLine("Неправильно указан тип операции");
				break;
		}

		return stateType;
	}
}