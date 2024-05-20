using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class ServiceHelpers
{
  public static TService GetProvider<TProvider, TService>(IServiceProvider provider)
    where TProvider : class, TService
    => provider.GetRequiredService<TProvider>();

  public static IServiceCollection AddProvider<TProvider, TService>(this IServiceCollection provider)
    where TProvider : class, TService
    where TService : class
    => provider.AddSingleton(GetProvider<TProvider, TService>);
}
