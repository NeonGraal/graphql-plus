using DiffEngine;

using GqlPlus.Encoding;
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
      .AddGenerators(b => b.AddSchemaGenerators())
      .AddSingleton<ISchemaGeneratorChecks, SchemaGeneratorChecks>()
      .AddModellerComponentTestBase();
}
