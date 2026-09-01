using GqlPlus.Matching;
using GqlPlus.Parsing;
using GqlPlus.Verifying;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public sealed class VerifierTestServices : IConfiguresServices
{
  public static IServiceCollection Configure(IServiceCollection services)
    => services
      .AddComponentParsers(false)
      .AddParsers(b => b
        .AddOperationParsers())
      .AddMatchers(b => b
        .AddSchemaMatchers())
      .AddVerifiers(b => b
        .AddSchemaVerifiers()
        .AddOperationVerifiers());
}
