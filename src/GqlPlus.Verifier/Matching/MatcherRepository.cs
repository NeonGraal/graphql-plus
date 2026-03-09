using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Matching;

internal class MatcherRepository : IMatcherRepository
{
  private readonly MatcherRepositoryState _state;
  private readonly ConcurrentDictionary<Type, object> _cache = new();
  private readonly Lazy<IEnumerable<ITypeMatcher>> _typeMatchers;

  public ILoggerFactory LoggerFactory { get; }

  public MatcherRepository(MatcherRepositoryState state, ILoggerFactory loggerFactory)
  {
    _state = state;
    LoggerFactory = loggerFactory;
    _typeMatchers = new(() => [.. state.TypeMatcherFactories.Select(f => f(this))]);
  }

  public IEnumerable<ITypeMatcher> TypeMatchers => _typeMatchers.Value;

  public Matcher<T>.D MatcherFor<T>()
  {
    Matcher<T>.I matcher = (Matcher<T>.I)_cache.GetOrAdd(typeof(T), _ => _state.Matchers[typeof(T)](this));
    return () => matcher;
  }
}
