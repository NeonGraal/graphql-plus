using GqlPlus.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Matching;

public class AllMatchersTests
{
  [Fact]
  public void AllMatchers_Repository_IsRegistered()
    => _services.GetService<IMatcherRepository>()
      .ShouldNotBeNull();

  [Fact]
  public void AllMatchers_MatcherForType_IsRegistered()
    => _services.GetRequiredService<IMatcherRepository>()
      .MatcherFor<IAstType>()
      .ShouldNotBeNull();

  [Fact]
  public void AllMatchers_TypeMatchers_ReturnNotEmpty()
    => _services.GetRequiredService<IMatcherRepository>()
    .TypeMatchers.ShouldNotBeEmpty();

  [Fact]
  public void AllMatchers_MatcherFactories_ReturnNotNull()
  {
    IMatcherRepository repo = _services.GetRequiredService<IMatcherRepository>();
    MatcherRepositoryBuilder builder = _services.GetRequiredService<MatcherRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Matchers.Values.Select(CheckMatcher)]);
  }

  [Fact]
  public void AllMatchers_AllTypeMatcherFactories_ReturnNotNull()
  {
    IMatcherRepository repo = _services.GetRequiredService<IMatcherRepository>();
    MatcherRepositoryBuilder builder = _services.GetRequiredService<MatcherRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.TypeMatchers.Select(CheckMatcher)]);
  }

  private static Action<IMatcherRepository> CheckMatcher(Factory<object, IMatcherRepository> factory)
    => r => factory(r)
        .ShouldNotBeNull($"Matcher for {factory.GetType().ExpandTypeName()} should not be null");

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddMatchers(b => b.AddConstraintTypeMatchers())
    .BuildServiceProvider();
}
