using System.Reflection;

using DiffEngine;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace GqlPlus;

public sealed class SchemaCodecTestServices : IConfiguresServices
{
  static SchemaCodecTestServices()
  {
    DiffRunner.MaxInstancesToLaunch(20);
    RenderFluid.Setup(
        new EmbeddedFileProvider(Assembly.GetExecutingAssembly(),
          "GqlPlus.Models"));
  }

  public static IServiceCollection Configure(IServiceCollection services)
    => services.AddModellerComponentTestBase();
}
