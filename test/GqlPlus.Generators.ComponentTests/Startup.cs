using DiffEngine;

using GqlPlus.Generating;
using GqlPlus.Sample;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public sealed class Startup : IConfiguresServices
{
  static Startup()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection Configure(IServiceCollection services)
    => services
      .AddGenerators()
      .AddSingleton<ISchemaGeneratorChecks, SchemaGeneratorChecks>()
      .AddModellerComponentTestBase();
}
