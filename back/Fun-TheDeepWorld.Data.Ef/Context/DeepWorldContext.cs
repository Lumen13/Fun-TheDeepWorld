using Microsoft.EntityFrameworkCore;

namespace Fun_TheDeepWorld.Data.Ef.Context;

public class DeepWorldContext : DbContext
{
    public DeepWorldContext(string connectionString
        , bool useInMemoryDatabase = false
        , string? dataBaseName = null
        ) : base(GetContextOptions(connectionString, useInMemoryDatabase, dataBaseName))
    {

    }

    public DeepWorldContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public void Migrate() { Database.Migrate(); }

    public bool IsRelational() => Database.IsRelational();

    private static DbContextOptions<DeepWorldContext> GetContextOptions(string connectionString
        , bool useInMemoryDatabase = false
        , string? dataBaseName = null
        )
    {
        DbContextOptionsBuilder<DeepWorldContext> optionsBuilder = new();

        if (useInMemoryDatabase && dataBaseName != null)
        {
            optionsBuilder.UseInMemoryDatabase(dataBaseName);
        }
        else if (!string.IsNullOrEmpty(connectionString))
        {
            optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        else
        {
            throw new Exception("Database connectionString is empty");
        }

        return optionsBuilder.Options;
    }
}