using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Modelling;

public class AllModellersTests
{
  [Fact]
  public void AllModellers_DefinesModeller_FieldKey()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddModellers()
      .BuildServiceProvider();

    services.GetService<IModeller<IGqlpFieldKey>>()
      .ShouldNotBeNull();
  }
}
