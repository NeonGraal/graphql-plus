using System.Reflection;

using DiffEngine;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

using GqlPlus.Encoding;

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
    => services.AddModellerComponentTestBase(b => b.AddSchemaEncoders());
}
