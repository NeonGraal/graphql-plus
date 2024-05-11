using DiffEngine;
using Fluid;
using GqlPlus.Modelling;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class Startup
{
  static Startup()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddComponentTest()
      .AddModellers();
}
