using SQLite;
using SteamGeneratorServer.Entities;

public class DatabaseHandler
{
	public SQLiteConnection Db { get; }

	public DatabaseHandler(string environmentPath)
	{
		var dbPath = Path.Combine(environmentPath, "simulator.db");
		Db = new SQLiteConnection(dbPath);
		Db.CreateTable<State>();
	}
}