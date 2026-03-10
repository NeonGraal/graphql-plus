using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

internal class MatcherRepositoryBuilder
  : BaseFactory<IMatcherRepository>, IMatcherRepositoryBuilder
{
  internal readonly FactoryDict Matchers = [];
  internal readonly List<Factory<ITypeMatcher, IMatcherRepository>> TypeMatcherFactories = [];

  public IMatcherRepositoryBuilder AddMatcher<T>(Factory<Matcher<T>.I, IMatcherRepository> factory)
    => this.FluentAction(b => b.Matchers[typeof(T)] = factory);

  public IMatcherRepositoryBuilder AddTypeMatcher<T, TMatcher>(Factory<TMatcher, IMatcherRepository> factory)
    where T : IGqlpType
    where TMatcher : class, Matcher<T>.I, ITypeMatcher
    => this.FluentAction(b => {
      b.Matchers[typeof(T)] = factory;
      b.TypeMatcherFactories.Add(factory);
    });

  public IMatcherRepositoryBuilder AddConstraintMatcher(Factory<ITypeMatcher, IMatcherRepository> factory)
    => this.FluentAction(b => b.TypeMatcherFactories.Add(factory));

  internal MatcherRepositoryState Build()
    => new(Matchers, [.. TypeMatcherFactories]);
}

internal sealed class MatcherRepositoryState
  : BaseFactory<IMatcherRepository>
{
  internal FactoryDict Matchers { get; }
  internal List<Factory<ITypeMatcher, IMatcherRepository>> TypeMatcherFactories { get; }

  public MatcherRepositoryState(
    FactoryDict matchers,
    List<Factory<ITypeMatcher, IMatcherRepository>> typeMatcherFactories)
  {
    Matchers = matchers;
    TypeMatcherFactories = typeMatcherFactories;
  }
}
