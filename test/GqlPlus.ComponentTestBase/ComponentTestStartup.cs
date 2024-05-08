using DiffEngine;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Parsing.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace GqlPlus;

public static class ComponentTestStartup
{
  static ComponentTestStartup()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection AddComponentTest(this IServiceCollection services)
    => services
      .AddLogging(lb => lb
        .AddXunitOutput(options => options.TimestampFormat = "HH:mm:ss.fff")
        .AddFilter("NullVerifier", LogLevel.Warning)
      )
      .AddSkippableFactSupport()
      .AddCommonParsers()
      .AddOperationParsers()
      .AddSchemaParsers()
      .AddMergers()
      .AddSingleton(_ => services);
}
