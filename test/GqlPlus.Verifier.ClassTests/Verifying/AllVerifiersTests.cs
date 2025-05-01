using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifying;

public class AllVerifiersTests
{
  [Fact]
  public void AllVerifiersShouldBeInTheSameAssembly()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddMergers()
      .AddVerifiers()
      .BuildServiceProvider();

    services.GetService<IVerify<IGqlpSchema>>()
      .ShouldNotBeNull();
  }
}
