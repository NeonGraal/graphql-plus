using GqlPlus.Modelling;
using GqlPlus.Encoding;
using GqlPlus.Resolving;

using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;
public static class ConfigureModellerComponentTestBase
{
  public static void AddModellerComponentTestBase(this IServiceCollection services)
    => services
      .AddComponentTest()
      .AddModellers()
      .AddResolvers()
      .AddEncoders()
      // Test support
      .AddTransient<ISchemaVerifyChecks, SchemaVerifyChecks>()
      .AddSingleton<IModelAndEncode, ModelAndEncode>();
}
