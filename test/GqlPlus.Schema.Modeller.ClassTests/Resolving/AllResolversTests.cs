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
    => ((Resolver<TypeEnumModel>)_services.GetRequiredService<IResolverRepository>()
      .ResolverFor<TypeEnumModel>()).I
      .ShouldNotBeNull();

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddResolvers(b => b.AddSchemaResolvers())
    .BuildServiceProvider();
}
