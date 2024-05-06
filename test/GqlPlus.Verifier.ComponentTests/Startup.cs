using DiffEngine;
using GqlPlus.Merging;
using GqlPlus.Modelling;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Parsing.Schema;
using GqlPlus.Verifying;
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
      .AddVerifiers()
      .AddMergers()
      .AddModellers()
      .AddSingleton(_ => services);
}
