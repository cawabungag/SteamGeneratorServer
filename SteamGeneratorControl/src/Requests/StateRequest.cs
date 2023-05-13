using SteamGeneratorControl.Data;
using SteamGeneratorServer.Entities;

namespace SteamGeneratorControl.Requests;

public class StateRequest : BaseRequest<State, CreateStateDto, UpdateStateDto, StateRequest>
{
	protected override string Endpoint => "states";
}