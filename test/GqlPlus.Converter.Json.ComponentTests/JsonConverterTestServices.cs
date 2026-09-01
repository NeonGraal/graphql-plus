using DiffEngine;
using GqlPlus.Encoding;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public sealed class JsonConverterTestServices : IConfiguresServices
{
  static JsonConverterTestServices()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection Configure(IServiceCollection services)
    => services.AddModellerComponentTestBase();
}
