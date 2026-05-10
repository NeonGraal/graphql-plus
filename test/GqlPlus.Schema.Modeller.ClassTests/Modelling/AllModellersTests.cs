using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Modelling;

public class AllModellersTests
{
  [Fact]
  public void AllModellers_Repository_IsRegistered()
    => _services.GetService<IModellerRepository>()
      .ShouldNotBeNull();

  [Fact]
  public void AllModellers_ModellerForFieldKey_IsRegistered()
    => ((Defer<IModeller<IAstFieldKey, SimpleModel>>.L)_services.GetRequiredService<IModellerRepository>()
      .ModellerFor<IAstFieldKey, SimpleModel>()).I
      .ShouldNotBeNull();

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddModellers()
    .BuildServiceProvider();
}
