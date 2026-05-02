using System.Runtime.CompilerServices;
using GqlPlus.Ast.Operation;
using GqlPlus.Ast.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Verifying;

public interface IVerifierRepository
{
  IVerify<T> VerifierFor<T>([CallerMemberName] string callerName = "");

  IVerifyAliased<T> AliasedFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased;

  IVerifyUsage<T> UsageFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased;

  IVerifyIdentified<TUsage, TIdentified> IdentifiedFor<TUsage, TIdentified>([CallerMemberName] string callerName = "")
    where TUsage : IAstError
    where TIdentified : IAstIdentified;

  IEnumerable<IVerifyDomain> GetDomains([CallerMemberName] string callerName = "");

  ILoggerFactory LoggerFactory { get; }

  Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "");

  IMerge<T> MergerFor<T>([CallerMemberName] string callerName = "")
    where T : IAstError;
}
