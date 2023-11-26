using GqlPlus.Verifier.Parse.Common;
using GqlPlus.Verifier.Parse.Operation;
using GqlPlus.Verifier.Parse.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.ClassTests;

public class Startup
{
  public void ConfigureServices(IServiceCollection services)
    => services
      .AddCommonParsers()
      .AddOperationParsers()
      .AddSchemaParsers();
}
