using System.Runtime.CompilerServices;

namespace GqlPlus.Matching;

internal class MatcherRepository(
  MatcherRepositoryBuilder state,
  ILoggerFactory loggerFactory
) : BaseRepository<IMatcherRepository>(loggerFactory)
  , IMatcherRepository
{
  public DeferList<ITypeMatcher>.D TypeMatchers([CallerMemberName] string callerName = "")
    => () => state.TypeMatchers.Select(MakeTypeMatcher);

  public MatcherOne<T>.D MatcherFor<T>([CallerMemberName] string callerName = "")
    => () => Cached<T, IMatcher<T>>(state.Matchers, "matcher for " + callerName, this);

  private ITypeMatcher MakeTypeMatcher(Factory<object, IMatcherRepository> factory)
    => (ITypeMatcher)factory(this);
}
