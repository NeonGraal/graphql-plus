using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Parse.Operation;
using GqlPlus.Verifier.Parse.Schema;
using GqlPlus.Verifier.Verification;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier;

public class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddCommonParsers()
      .AddOperationParsers()
      .AddSchemaParsers()
      .AddVerifiers()
      .AddMergers();
}
