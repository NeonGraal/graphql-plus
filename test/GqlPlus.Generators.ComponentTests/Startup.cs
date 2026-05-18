using DiffEngine;

using GqlPlus.Encoding;
using GqlPlus.Generating;
using GqlPlus.Sample;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class Startup
{
  static Startup()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddGenerators(b => b.AddSchemaGenerators())
      .AddSingleton<ISchemaGeneratorChecks, SchemaGeneratorChecks>()
      .AddModellerComponentTestBase(b => b.AddSchemaEncoders());
}
