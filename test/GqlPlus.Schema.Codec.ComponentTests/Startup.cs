using System.Reflection;
using System.Runtime.CompilerServices;

using DiffEngine;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace GqlPlus;

public sealed class Startup : IConfiguresServices
{
  static Startup()
  {
    DiffRunner.MaxInstancesToLaunch(20);
    RenderFluid.Setup(
        new EmbeddedFileProvider(Assembly.GetExecutingAssembly(),
          "GqlPlus.Models"));
  }

  public static IServiceCollection Configure(IServiceCollection services)
    => services.AddModellerComponentTestBase();
}
