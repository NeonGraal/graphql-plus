using System.Runtime.CompilerServices;
using GqlPlus.Ast.Operation;
using GqlPlus.Ast.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Verifying;

internal class VerifierRepository(
  VerifierRepositoryBuilder state,
  ILoggerFactory loggerFactory,
  IMatcherRepository matchers,
  IMergerRepository mergers
) : BaseRepository<IVerifierRepository>(loggerFactory)
  , IVerifierRepository
{
  public Verifier<T> VerifierFor<T>([CallerMemberName] string callerName = "")
    => new(() => Cached<T, IVerify<T>>(state.Verifiers, "verify for " + callerName, this));

  public AliasVerifier<T> AliasedFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased
    => new(() => Cached<T, IVerifyAliased<T>>(state.Aliased, "aliased for " + callerName, this));
  public UsageVerifier<T> UsageFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased
    => new(() => Cached<T, IVerifyUsage<T>>(state.Usages, "usage for " + callerName, this));

  public IdentifiedVerifier<TUsage, TIdentified> IdentifiedFor<TUsage, TIdentified>([CallerMemberName] string callerName = "")
    where TUsage : IAstError
    where TIdentified : IAstIdentified
    => new(() => Cached<(TUsage, TIdentified), IVerifyIdentified<TUsage, TIdentified>>(
      state.Identified,
      "identified for " + callerName, this));

  public DeferList<IVerifyDomain>.D GetDomains([CallerMemberName] string callerName = "")
    => () => state.Domains.Select(f => (IVerifyDomain)f(this));

  public Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "")
    => matchers.MatcherFor<T>(callerName);

  public MergerOne<T>.D MergerFor<T>([CallerMemberName] string callerName = "")
    where T : IAstError
    => mergers.MergerFor<T>(callerName);
}
