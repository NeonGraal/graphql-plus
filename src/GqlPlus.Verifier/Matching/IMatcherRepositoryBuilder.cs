using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

public interface IMatcherRepositoryBuilder
{
  IMatcherRepositoryBuilder AddMatcher<T>(Factory<Matcher<T>.I, IMatcherRepository> factory);

  IMatcherRepositoryBuilder AddTypeMatcher<T, TMatcher>(Factory<TMatcher, IMatcherRepository> factory)
    where T : IAstType
    where TMatcher : class, Matcher<T>.I, ITypeMatcher;

  IMatcherRepositoryBuilder AddConstraintMatcher(Factory<ITypeMatcher, IMatcherRepository> factory);
}
