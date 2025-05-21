using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifying;

public class AllVerifiersTests
{
  [Fact]
  public void AllVerifiers_DefinesVerifySchema()
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
