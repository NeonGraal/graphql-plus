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
  public IVerify<T> VerifierFor<T>([CallerMemberName] string callerName = "")
    => Cached<T, IVerify<T>>(state.Verifiers, "verify for " + callerName, this);

  public IVerifyAliased<T> AliasedFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased
    => Cached<T, IVerifyAliased<T>>(state.Aliased, "aliased for " + callerName, this);
  public IVerifyUsage<T> UsageFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased
    => Cached<T, IVerifyUsage<T>>(state.Usages, "usage for " + callerName, this);

  public IVerifyIdentified<TUsage, TIdentified> IdentifiedFor<TUsage, TIdentified>([CallerMemberName] string callerName = "")
    where TUsage : IAstError
    where TIdentified : IAstIdentified
    => Cached<(TUsage, TIdentified), IVerifyIdentified<TUsage, TIdentified>>(
      state.Identified,
      "identified for " + callerName, this);

  public IEnumerable<IVerifyDomain> GetDomains([CallerMemberName] string callerName = "")
    => state.Domains.Select(f => (IVerifyDomain)f(this));

  public Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "")
    => matchers.MatcherFor<T>(callerName);

  public Defer<IMerge<T>>.D MergerFor<T>([CallerMemberName] string callerName = "")
    where T : IAstError
    => mergers.MergerFor<T>(callerName);
}
