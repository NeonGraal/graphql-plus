using DiffEngine;
using GqlPlus.Parse;
using GqlPlus.Parse.Operation;
using GqlPlus.Parse.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace GqlPlus;

public static class Startup
{
  static Startup()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddLogging(lb => lb
        .AddXunitOutput(options => options.TimestampFormat = "HH:mm:ss.fff")
        .AddFilter("NullVerifier", LogLevel.Warning)
      )
      .AddSkippableFactSupport()
      .AddCommonParsers()
      .AddOperationParsers()
      .AddSchemaParsers()
      .AddSingleton(_ => services);
}
