namespace GqlPlus.Matching;

internal class MatcherRepository
  : BaseRepository<IMatcherRepository>
  , IMatcherRepository
{
  private readonly MatcherRepositoryBuilder _state;
  private readonly Lazy<IEnumerable<ITypeMatcher>> _typeMatchers;

  public MatcherRepository(MatcherRepositoryBuilder state, ILoggerFactory loggerFactory)
    : base(loggerFactory)
  {
    _state = state;
    _typeMatchers = new(()
      => [.. state.TypeMatchers.Select(f => (ITypeMatcher)f(this))]);
  }

  public IEnumerable<ITypeMatcher> TypeMatchers => _typeMatchers.Value;

  public Matcher<T>.D MatcherFor<T>()
    => () => Cached<T, Matcher<T>.I>(_state.Matchers, "matcher", this);
}
