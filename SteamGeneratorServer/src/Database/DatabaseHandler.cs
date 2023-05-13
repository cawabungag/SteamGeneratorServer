using SQLite;
using SteamGeneratorServer.Entities.Measure;
using SteamGeneratorServer.Entities.State;

namespace SteamGeneratorServer.Database;

public class DatabaseHandler
{
	public SQLiteConnection Db { get; }

	public DatabaseHandler(string environmentPath)
	{
		var dbPath = Path.Combine(environmentPath, "simulator.db");
		Db = new SQLiteConnection(dbPath);
		Db.CreateTable<State>();
		Db.CreateTable<Measure>();
	}
}