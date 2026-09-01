using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

// Marker implemented by each namespace-scoped `Startup` class so it can be
// used as the type argument of ComponentFixture<TStartup>.
public interface IConfiguresServices
{
  static abstract IServiceCollection Configure(IServiceCollection services);
}

// Test fixture (used via Xunit's IClassFixture<>) that builds the services
// for a namespace-scoped Startup, replacing Xunit.DependencyInjection's
// constructor injection with a plain IServiceProvider built once per test class.
public sealed class ComponentFixture<TStartup> : IDisposable
  where TStartup : IConfiguresServices
{
  public IServiceCollection ServiceCollection { get; } = TStartup.Configure(new ServiceCollection());
  public IServiceProvider Services { get; }

  public ComponentFixture()
    => Services = ServiceCollection.BuildServiceProvider();

  public TService GetService<TService>()
    where TService : notnull
    => Services.GetRequiredService<TService>();

  public void Dispose()
    => (Services as IDisposable)?.Dispose();
}
