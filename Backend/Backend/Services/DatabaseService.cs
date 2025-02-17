using MySql.Data.MySqlClient;

namespace Backend.Services;

public class DatabaseService : IDisposable
{
    private readonly MySqlConnection _connection;

    private const string Server = "localhost";
    private const string Database = "gossip";
    private const string User = "root";
    private const string Password = "root";

    public DatabaseService()
    {
        const string connectionStr = $"Server={Server};Database={Database};User ID={User};Password={Password};Pooling=true;";

        _connection = new MySqlConnection(connectionStr);
        _connection.Open();
    }

    public MySqlConnection Connection => _connection;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
            return;

        _connection?.Close();
        _connection?.Dispose();
    }

    ~DatabaseService() => Dispose(false);
}