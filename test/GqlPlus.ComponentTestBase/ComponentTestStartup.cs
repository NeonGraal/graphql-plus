using DiffEngine;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection.Logging;

namespace GqlPlus;

public static class ComponentTestStartup
{
  static ComponentTestStartup()
  {
    DiffRunner.MaxInstancesToLaunch(20);
    DiFluid.Register<DiService>();
    DiFluid.Register<TypeIdName>();
  }

  public static IServiceCollection AddComponentTest(this IServiceCollection services, bool checkEnv = true)
    => services
      .AddLogging(lb => {
        lb.AddFilter("NullVerifier", LogLevel.Warning);
        lb.AddXunitOutput(options => options.TimestampFormat = "HH:mm:ss.fff");
        if (checkEnv && string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("GQLPLUS_TEST_LOGGING"))) {
          lb.AddFilter(l => l == LogLevel.Critical);
        }
      })
      .AddParsers(b => b.AddCommonParsers())
      .AddSingleton(_ => services);

  public static IServiceCollection AddComponentParsers(this IServiceCollection services, bool checkEnv = true)
    => services
      .AddComponentTest(checkEnv)
      .AddTransient<ISchemaParseChecks, SchemaParseChecks>()
      .AddParsers(b => b.AddSchemaParsers())
      .AddMergers(b => b.AddSchemaMergers());
}
