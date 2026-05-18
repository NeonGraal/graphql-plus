using GqlPlus.Encoding;
using GqlPlus.Modelling;
using GqlPlus.Resolving;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class ConfigureModellerComponentTestBase
{
  public static void AddModellerComponentTestBase(this IServiceCollection services,
      Action<IEncoderRepositoryBuilder> configureEncoders)
      => services
        .AddComponentParsers()

        .AddModellers(b => b.AddSchemaModellers())
        .AddResolvers(b => b.AddSchemaResolvers())
        .AddEncoders(configureEncoders)

        // Test support
        .AddTransient<ISchemaVerifyChecks, SchemaVerifyChecks>()
        .AddSingleton<IModelAndEncode, ModelAndEncode>();
}
