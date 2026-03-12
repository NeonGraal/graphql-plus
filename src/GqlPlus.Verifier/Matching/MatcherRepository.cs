namespace GqlPlus.Matching;

internal class MatcherRepository
  : BaseRepository<IMatcherRepository>
  , IMatcherRepository
{
  private readonly MatcherRepositoryState _state;
  private readonly Lazy<IEnumerable<ITypeMatcher>> _typeMatchers;

  public MatcherRepository(MatcherRepositoryState state, ILoggerFactory loggerFactory)
    : base(loggerFactory)
  {
    _state = state;
    _typeMatchers = new(() => [.. state.TypeMatcherFactories.Select(f => f(this))]);
  }

  public IEnumerable<ITypeMatcher> TypeMatchers => _typeMatchers.Value;

  public Matcher<T>.D MatcherFor<T>()
    => () => Cached<T, Matcher<T>.I>(_state.Matchers, "matcher", this);
}
