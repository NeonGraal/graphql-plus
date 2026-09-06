using DiffEngine;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Resolving;

public sealed class ResolverTestServices : IConfiguresServices
{
  static ResolverTestServices()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection Configure(IServiceCollection services)
    => services.AddModellerComponentTestBase(true, true);
}
