using Dapper;
using Microsoft.Data.Sqlite;

namespace TaskForger;

public class ConnectionBuilder: IDisposable, IAsyncDisposable
{
    public SqliteConnection Connection { get; } = new(GetConnectionString());
    private static string GetConnectionString()
    {
        return "Data Source=tasks.db";
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Connection.Close();
        Connection.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        Connection.Close();
        await Connection.DisposeAsync();
    }
}