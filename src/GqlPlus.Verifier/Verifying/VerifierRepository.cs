using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifying;

internal class VerifierRepository
  : BaseRepository<IVerifierRepository>
  , IVerifierRepository
{
  private readonly VerifierRepositoryState _state;
  private readonly IMatcherRepository _matchers;
  private readonly IMergerRepository _mergers;
  private readonly Lazy<IEnumerable<IVerifyDomain>> _domains;


  public VerifierRepository(
    VerifierRepositoryState state,
    ILoggerFactory loggerFactory,
    IMatcherRepository matchers,
    IMergerRepository mergers)
    : base(loggerFactory)
  {
    _state = state;
    _matchers = matchers;
    _mergers = mergers;
    _domains = new(() => [.. state.Domains.Select(f => (IVerifyDomain)f.Invoke(this))]);
  }

  public IVerify<T> VerifierFor<T>()
    => Cached<T, IVerify<T>>(_state.Verifiers, "verify", this);

  public IVerifyAliased<T> AliasedFor<T>()
    where T : IGqlpAliased
    => Cached<T, IVerifyAliased<T>>(_state.Aliased, "aliased", this);

  public IVerifyUsage<T> UsageFor<T>()
    where T : IGqlpAliased
    => Cached<T, IVerifyUsage<T>>(_state.Usages, "usage", this);

  public IVerifyIdentified<TUsage, TIdentified> IdentifiedFor<TUsage, TIdentified>()
    where TUsage : IGqlpError
    where TIdentified : IGqlpIdentified
    => Cached<(TUsage, TIdentified), IVerifyIdentified<TUsage, TIdentified>>(
      _state.Identified,
      "identified", this);

  public IEnumerable<IVerifyDomain> GetDomains()
    => _domains.Value;

  public Matcher<T>.D MatcherFor<T>()
    => _matchers.MatcherFor<T>();

  public IMerge<T> MergerFor<T>()
    where T : IGqlpError
    => _mergers.MergerFor<T>();
}
