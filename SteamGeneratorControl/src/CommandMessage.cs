namespace SteamGeneratorControl;

public class CommandMessage
{
	public string Title { get; }
	public string Description { get; }
	public ConsoleColor Color { get; }

	public CommandMessage(string title, string description, ConsoleColor color = ConsoleColor.Black)
	{
		Title = title;
		Description = description;
		Color = color;
	}
}