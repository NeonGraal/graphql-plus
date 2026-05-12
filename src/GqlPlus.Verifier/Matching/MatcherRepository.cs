using System.Runtime.CompilerServices;

namespace GqlPlus.Matching;

internal class MatcherRepository(
  MatcherRepositoryBuilder state,
  ILoggerFactory loggerFactory
) : BaseRepository<IMatcherRepository>(loggerFactory)
  , IMatcherRepository
{
  public DeferList<ITypeMatcher>.D TypeMatchers([CallerMemberName] string callerName = "")
    => () => InstancesFor<ITypeMatcher>(state.TypeMatchers, this);

  public Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "")
    => () => Cached<T, IMatcher<T>>(state.Matchers, "matcher for " + callerName, this);
}
