using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Resolving;

public class AllResolversTests
{
  [Fact]
  public void AllResolvers_Repository_IsRegistered()
    => _services.GetService<IResolverRepository>()
      .ShouldNotBeNull();

  [Fact]
  public void AllResolvers_ResolverForEnum_IsRegistered()
    => ((Defer<IResolver<TypeEnumModel>>.L)_services.GetRequiredService<IResolverRepository>()
      .ResolverFor<TypeEnumModel>()).I
      .ShouldNotBeNull();

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddResolvers()
    .BuildServiceProvider();
}
