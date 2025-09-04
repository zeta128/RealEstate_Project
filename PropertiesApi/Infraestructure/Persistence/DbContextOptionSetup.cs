using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace PropertiesApi.Infraestructure;

public class DbContextOptionSetup
{
    public static void ConfigureReadOptions(DbContextOptionsBuilder options, string connectionString)
    {
        options
            .UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
                sqlOptions.CommandTimeout(90);
                // Optimizar para lecturas
                sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            })
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .EnableSensitiveDataLogging(false)
            .EnableDetailedErrors(false)
            .ConfigureWarnings(warnings =>
                warnings.Ignore(CoreEventId.MultipleNavigationProperties));
    }

    public static void ConfigureWriteOptions(DbContextOptionsBuilder options, string connectionString)
    {
        options
            .UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
                sqlOptions.CommandTimeout(90);
                // Optimizar para escrituras
                sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
            })
            .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
            .EnableSensitiveDataLogging(false)
            .EnableDetailedErrors(false);
    }
}