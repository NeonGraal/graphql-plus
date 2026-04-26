using GqlPlus.Encoding;
using GqlPlus.Modelling;
using GqlPlus.Resolving;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class ConfigureModellerComponentTestBase
{
  public static void AddModellerComponentTestBase(this IServiceCollection services)
    => services
      .AddComponentParsers()

      .AddModellers()
      .AddResolvers()
      .AddEncoders()

      // Test support
      .AddTransient<ISchemaVerifyChecks, SchemaVerifyChecks>()
      .AddSingleton<IModelAndEncode, ModelAndEncode>();
}
