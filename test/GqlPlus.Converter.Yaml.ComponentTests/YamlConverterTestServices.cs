using DiffEngine;

using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public sealed class YamlConverterTestServices : IConfiguresServices
{
  static YamlConverterTestServices()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection Configure(IServiceCollection services)
    => services.AddModellerComponentTestBase();
}
