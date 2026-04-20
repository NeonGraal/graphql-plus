using GqlPlus.Ast;
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
    => _services.GetRequiredService<IModellerRepository>()
      .ModellerFor<IAstFieldKey, SimpleModel>()
      .ShouldNotBeNull();

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddModellers()
    .BuildServiceProvider();
}
