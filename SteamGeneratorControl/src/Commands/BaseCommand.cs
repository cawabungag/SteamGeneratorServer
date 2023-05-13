namespace SteamGeneratorControl.Commands;

public abstract class BaseCommand
{
	protected string[] Parameters;
	public abstract Task<CommandMessage[]> Execute();
	public abstract bool IsLoop { get; }
	public abstract string Command { get; }
	public void SetParams(params string[] parameters) => Parameters = parameters;
}