using System.Collections.Concurrent;
using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Verifying;

internal class VerifierRepository : IVerifierRepository
{
  private readonly VerifierRepositoryState _state;
  private readonly IServiceProvider _services;
  private readonly ConcurrentDictionary<Type, object> _cache = new();
  private readonly Lazy<IEnumerable<IVerifyDomain>> _domains;

  public VerifierRepository(VerifierRepositoryState state, IServiceProvider services)
  {
    _state = state;
    _services = services;
    _domains = new(() => [.. state.Domains.Select(f => (IVerifyDomain)f.Invoke(this, services))]);
  }

  private TResult Cached<TKey, TResult>(Dictionary<TKey, VerifierFactory<object>> factories, TKey key, string label)
    where TKey : notnull
    => (TResult)_cache.GetOrAdd(
      typeof(TResult),
      _ => {
        if (factories.TryGetValue(key, out VerifierFactory<object>? factory)) {
          return factory.Invoke(this, _services);
        }

        throw new InvalidOperationException($"No {label} verifier registration found for type '{key}'.");
      });

  public IVerify<T> VerifierFor<T>()
    => Cached<Type, IVerify<T>>(_state.Verifiers, typeof(T), "verify");

  public IVerifyAliased<T> AliasedFor<T>()
    where T : IGqlpAliased
    => Cached<Type, IVerifyAliased<T>>(_state.Aliased, typeof(T), "aliased");

  public IVerifyUsage<T> UsageFor<T>()
    where T : IGqlpAliased
    => Cached<Type, IVerifyUsage<T>>(_state.Usages, typeof(T), "usage");

  public IVerifyIdentified<TUsage, TIdentified> IdentifiedFor<TUsage, TIdentified>()
    where TUsage : IGqlpError
    where TIdentified : IGqlpIdentified
    => Cached<(Type, Type), IVerifyIdentified<TUsage, TIdentified>>(
      _state.Identified,
      (typeof(TUsage), typeof(TIdentified)),
      "identified");

  public IEnumerable<IVerifyDomain> GetDomains()
    => _domains.Value;
}
