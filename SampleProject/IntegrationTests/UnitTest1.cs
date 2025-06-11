using Npgsql;

namespace IntegrationTests;

public class UnitTest1
{
    [Fact]
    public void CheckSqlConnection()
    {
        var connectionString = "Host=localhost;Port=5432;Username=topSecretUser;Password=topSecretPassword;Database=topSecretDb";

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        using var command = new NpgsqlCommand("SELECT 1", connection);
        var result = command.ExecuteScalar();

        Assert.Equal(1, result);
    }
}
