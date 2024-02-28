using DiffEngine;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Modelling;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Parse.Operation;
using GqlPlus.Verifier.Parse.Schema;
using GqlPlus.Verifier.Verification;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection.Logging;

namespace GqlPlus.Verifier;

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
      .AddCommonParsers()
      .AddOperationParsers()
      .AddSchemaParsers()
      .AddVerifiers()
      .AddMergers()
      .AddModellers()
      .AddSingleton(_ => services);
}
