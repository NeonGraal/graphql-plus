using GqlPlus.Encoding;
using GqlPlus.Modelling;
using GqlPlus.Resolving;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class ConfigureModellerComponentTestBase
{
  public static IServiceCollection AddModellerComponentTestBase(this IServiceCollection services, bool includeResolvers, bool includeEncoders)
  {
    services.AddComponentParsers();

    services.AddModellers(b => b.AddSchemaModellers());
    if (includeResolvers) {
      services.AddResolvers(b => b.AddSchemaResolvers());
    }

    if (includeEncoders) {
      services
        .AddEncoders(b => b.AddSchemaEncoders())
        .AddSingleton<IModelAndEncode, ModelAndEncode>()
        .AddTransient<ISchemaVerifyChecks, SchemaVerifyChecks>();
    }

    // Test support
    return services;
  }
}
