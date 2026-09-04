using DiffEngine;

using GqlPlus.Generating;
using GqlPlus.Sample;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public sealed class GeneratorTestServices : IConfiguresServices
{
  static GeneratorTestServices()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection Configure(IServiceCollection services)
    => services
      .AddGenerators()
      .AddSingleton<ISchemaGeneratorChecks, SchemaGeneratorChecks>()
      .AddModellerComponentTestBase();
}
