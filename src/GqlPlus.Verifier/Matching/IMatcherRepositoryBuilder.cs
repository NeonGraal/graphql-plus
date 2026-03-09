using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

public interface IMatcherRepositoryBuilder
{
  IMatcherRepositoryBuilder AddMatcher<T>(MatcherFactory<Matcher<T>.I> factory);

  IMatcherRepositoryBuilder AddTypeMatcher<T, TMatcher>(MatcherFactory<TMatcher> factory)
    where T : IGqlpType
    where TMatcher : class, Matcher<T>.I, ITypeMatcher;

  IMatcherRepositoryBuilder AddConstraintMatcher(MatcherFactory<ITypeMatcher> factory);
}

public delegate T MatcherFactory<out T>(IMatcherRepository matchers)
  where T : class;
