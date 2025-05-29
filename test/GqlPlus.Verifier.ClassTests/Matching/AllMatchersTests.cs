using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Matching;

public class AllMatchersTests
{
  [Fact]
  public void AllMatchers_DefinesMatcherSchema()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddMergers()
      .AddMatchers()
      .BuildServiceProvider();

    services.GetService<IMatch<IGqlpType, IGqlpType>>()
      .ShouldNotBeNull();
  }
}
