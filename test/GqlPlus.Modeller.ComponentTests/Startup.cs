using System.Reflection;

using DiffEngine;

using GqlPlus.Convert;
using GqlPlus.Modelling;
using GqlPlus.Resolving;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace GqlPlus;

public static class Startup
{
  static Startup()
  {
    DiffRunner.MaxInstancesToLaunch(20);
    RenderFluid.Setup(
        new EmbeddedFileProvider(Assembly.GetExecutingAssembly(),
          "GqlPlus.Models"));
  }

  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddComponentTest()
      .AddModellers()
      .AddResolvers()
      .AddRenderers()
      // Test support
      .AddSingleton<IModelAndRender, ModelAndRender>();
}
