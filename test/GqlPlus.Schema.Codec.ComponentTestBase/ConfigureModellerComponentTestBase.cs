using GqlPlus.Encoding;
using GqlPlus.Modelling;
using GqlPlus.Resolving;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class ConfigureModellerComponentTestBase
{
  public static void AddModellerComponentTestBase(this IServiceCollection services,
      Action<IEncoderRepositoryBuilder>? configureEncoders = null)
      => services
        .AddComponentParsers()

        .AddModellers()
        .AddResolvers()
        .AddEncoders(configureEncoders)

        // Test support
        .AddTransient<ISchemaVerifyChecks, SchemaVerifyChecks>()
        .AddSingleton<IModelAndEncode, ModelAndEncode>();
  }
