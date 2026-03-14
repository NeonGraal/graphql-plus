using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Matching;

public class AllMatchersTests
{
  [Fact]
  public void AllMatchers_Repository_IsRegistered()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddMatchers(b => b.AddConstraintTypeMatchers())
      .BuildServiceProvider();

    services.GetService<IMatcherRepository>()
      .ShouldNotBeNull();
  }

  [Fact]
  public void AllMatchers_Repository_ProvidesMatcherForSchema()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddMatchers(b => b.AddConstraintTypeMatchers())
      .BuildServiceProvider();

    services.GetRequiredService<IMatcherRepository>()
      .MatcherFor<IGqlpType>()
      .ShouldNotBeNull();
  }
}
