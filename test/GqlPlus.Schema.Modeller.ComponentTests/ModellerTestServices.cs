using DiffEngine;

using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public sealed class ModellerTestServices : IConfiguresServices
{
  static ModellerTestServices()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection Configure(IServiceCollection services)
    => services.AddModellerComponentTestBase();
}
