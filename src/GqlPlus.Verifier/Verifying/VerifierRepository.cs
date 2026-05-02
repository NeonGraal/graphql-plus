using System.Runtime.CompilerServices;
using GqlPlus.Ast.Operation;
using GqlPlus.Ast.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Verifying;

internal class VerifierRepository
  : BaseRepository<IVerifierRepository>
  , IVerifierRepository
{
  private readonly VerifierRepositoryBuilder _state;
  private readonly IMatcherRepository _matchers;
  private readonly IMergerRepository _mergers;
  private readonly Lazy<IEnumerable<IVerifyDomain>> _domains;

  public VerifierRepository(
    VerifierRepositoryBuilder state,
    ILoggerFactory loggerFactory,
    IMatcherRepository matchers,
    IMergerRepository mergers)
    : base(loggerFactory)
  {
    _state = state;
    _matchers = matchers;
    _mergers = mergers;
    _domains = new(()
      => [.. state.Domains.Select(f
        => (IVerifyDomain)f.Invoke(this))]);
  }

  public IVerify<T> VerifierFor<T>([CallerMemberName] string callerName = "")
    => Cached<T, IVerify<T>>(_state.Verifiers, "verify for " + callerName, this);

  public IVerifyAliased<T> AliasedFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased
    => Cached<T, IVerifyAliased<T>>(_state.Aliased, "aliased for " + callerName, this);
  public IVerifyUsage<T> UsageFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased
    => Cached<T, IVerifyUsage<T>>(_state.Usages, "usage for " + callerName, this);

  public IVerifyIdentified<TUsage, TIdentified> IdentifiedFor<TUsage, TIdentified>([CallerMemberName] string callerName = "")
    where TUsage : IAstError
    where TIdentified : IAstIdentified
    => Cached<(TUsage, TIdentified), IVerifyIdentified<TUsage, TIdentified>>(
      _state.Identified,
      "identified for " + callerName, this);

  public IEnumerable<IVerifyDomain> GetDomains([CallerMemberName] string callerName = "")
    => _domains.Value;

  public Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "")
    => _matchers.MatcherFor<T>(callerName);

  public IMerge<T> MergerFor<T>([CallerMemberName] string callerName = "")
    where T : IAstError
    => _mergers.MergerFor<T>();
}
