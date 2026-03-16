using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

internal class MatcherRepositoryBuilder
  : BaseFactory<IMatcherRepository>
  , IMatcherRepositoryBuilder
{
  internal readonly FactoryDict Matchers = [];
  internal readonly FactoryList TypeMatchers = [];

  public IMatcherRepositoryBuilder AddMatcher<T>(Factory<Matcher<T>.I, IMatcherRepository> factory)
    => this.FluentAction(b => b.Matchers[typeof(T)] = factory);

  public IMatcherRepositoryBuilder AddTypeMatcher<T, TMatcher>(Factory<TMatcher, IMatcherRepository> factory)
    where T : IGqlpType
    where TMatcher : class, Matcher<T>.I, ITypeMatcher
    => this.FluentAction(b => {
      b.Matchers[typeof(T)] = factory;
      b.TypeMatchers.Add(factory);
    });

  public IMatcherRepositoryBuilder AddConstraintMatcher(Factory<ITypeMatcher, IMatcherRepository> factory)
    => this.FluentAction(b => b.TypeMatchers.Add(factory));
}
