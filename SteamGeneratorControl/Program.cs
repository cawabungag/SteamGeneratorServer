using SteamGeneratorControl.Commands;

BaseCommand? currentCommand = null;
var commands = new Dictionary<string, BaseCommand>();

var readMeasureCommand = new ReadMeasureCommand();
var statrtStateCommand = new StartStateCommand();
var readStatesCommand = new ReadStatesCommand();
var stopStateCommand = new StopStateCommand();
var resetStateCommand = new ResetCommand();

commands.Add(readMeasureCommand.Command, readMeasureCommand);
commands.Add(statrtStateCommand.Command, statrtStateCommand);
commands.Add(readStatesCommand.Command, readStatesCommand);
commands.Add(stopStateCommand.Command, stopStateCommand);
commands.Add(resetStateCommand.Command, resetStateCommand);

Task ReadLine()
{
	while (true)
	{
		var inputCommand = Console.ReadLine();
		if (inputCommand == "help")
		{
			Console.WriteLine($"Список доступных команд: {string.Join("\n", commands.Keys)}");
			continue;
		}

		var parameters = inputCommand.Split(" ");
		if (commands.TryGetValue(parameters[0], out var command))
		{
			currentCommand = command;
			currentCommand.SetParams(parameters[1], parameters[2]);
			Console.WriteLine("Команда: " + inputCommand + " добавлена");
		}
		else
		{
			Console.WriteLine("Неудалось найти команду: " + inputCommand + "");
		}
	}
}

Task.Run(ReadLine);

while (true)
{
	if (currentCommand != null)
	{
		var messages = await currentCommand.Execute();
		if (messages == null)
		{
			Console.WriteLine($"Не удвлось выполнить команду: {currentCommand.Command}");
			currentCommand = null;
			Task.Run(ReadLine);
		}

		foreach (var message in messages)
		{
			// Console.BackgroundColor = message.Color;
			Console.WriteLine($"{message.Title} {message.Description}");
			Console.ResetColor();
		}

		if (!currentCommand.IsLoop)
		{
			currentCommand = null;
			Task.Run(ReadLine);
		}

		if (currentCommand != null)
		{
			if (messages == null || messages.Length == 0)
				if (currentCommand.IsLoop)
					Task.Run(ReadLine);
		}
	}

	Thread.Sleep(1000);
}