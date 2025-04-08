using GqlPlus.Modelling;
using GqlPlus.Rendering;
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
      .AddRenderers()
      // Test support
      .AddTransient<ISchemaVerifyChecks, SchemaVerifyChecks>()
      .AddSingleton<IModelAndRender, ModelAndRender>();
}
