using DiffEngine;

using Microsoft.Extensions.DependencyInjection;

using GqlPlus.Encoding;

namespace GqlPlus;

public static class Startup
{
  static Startup()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static void ConfigureServices(IServiceCollection services)
    => services.AddModellerComponentTestBase(b => b.AddSchemaEncoders());
}
