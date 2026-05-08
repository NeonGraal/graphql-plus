using System.Runtime.CompilerServices;

namespace GqlPlus.Matching;

internal class MatcherRepository(
  MatcherRepositoryBuilder state,
  ILoggerFactory loggerFactory
) : BaseRepository<IMatcherRepository>(loggerFactory)
  , IMatcherRepository
{
  public IEnumerable<Factory<ITypeMatcher, IMatcherRepository>> TypeMatchers
    => state.TypeMatchers.Select(MakeTypeMatcher);

  public Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "")
    => () => Cached<T, Matcher<T>.I>(state.Matchers, "matcher for " + callerName, this);

  private static Factory<ITypeMatcher, IMatcherRepository> MakeTypeMatcher(Factory<object, IMatcherRepository> factory)
    => r => (ITypeMatcher)factory(r);
}
