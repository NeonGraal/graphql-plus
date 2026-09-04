using DiffEngine;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using MartinCostello.Logging.XUnit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GqlPlus;

// MartinCostello.Logging.XUnit.v3's own AmbientTestOutputHelperAccessor is internal,
// so this reads xUnit v3's ambient TestContext directly to route log output to
// whichever test is currently running, without needing ITestOutputHelper injected
// into every fixture-built service.
internal sealed class AmbientTestOutputHelperAccessor : ITestOutputHelperAccessor
{
  public ITestOutputHelper? OutputHelper
  {
    get => TestContext.Current?.TestOutputHelper;
    set { }
  }
}

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
        lb.AddXUnit(new AmbientTestOutputHelperAccessor(), options => options.TimestampFormat = "HH:mm:ss.fff");
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
      .AddParsers(b => b
        .AddSchemaParsers()
        .AddOperationParsers())
      .AddMergers(b => b.AddSchemaMergers());
}
