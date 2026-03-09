using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

internal class MatcherRepositoryBuilder
  : IMatcherRepositoryBuilder
{
  internal readonly MatcherFactoryDict Matchers = [];
  internal readonly List<MatcherFactory<ITypeMatcher>> TypeMatcherFactories = [];

  public IMatcherRepositoryBuilder AddMatcher<T>(MatcherFactory<Matcher<T>.I> factory)
    => this.FluentAction(b => b.Matchers[typeof(T)] = factory);

  public IMatcherRepositoryBuilder AddTypeMatcher<T, TMatcher>(MatcherFactory<TMatcher> factory)
    where T : IGqlpType
    where TMatcher : class, Matcher<T>.I, ITypeMatcher
    => this.FluentAction(b => {
      b.Matchers[typeof(T)] = factory;
      b.TypeMatcherFactories.Add(factory);
    });

  public IMatcherRepositoryBuilder AddConstraintMatcher(MatcherFactory<ITypeMatcher> factory)
    => this.FluentAction(b => b.TypeMatcherFactories.Add(factory));

  internal MatcherRepositoryState Build()
    => new(Matchers, [.. TypeMatcherFactories]);
}

internal sealed class MatcherRepositoryState(
  MatcherFactoryDict matchers,
  List<MatcherFactory<ITypeMatcher>> typeMatcherFactories)
{
  internal MatcherFactoryDict Matchers { get; } = matchers;
  internal List<MatcherFactory<ITypeMatcher>> TypeMatcherFactories { get; } = typeMatcherFactories;
}

internal class MatcherFactoryDict : Dictionary<Type, MatcherFactory<object>>;
