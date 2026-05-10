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
  : IRepository
{
  Defer<IVerify<T>>.D VerifierFor<T>([CallerMemberName] string callerName = "");

  Defer<IVerifyAliased<T>>.D AliasedFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased;

  Defer<IVerifyUsage<T>>.D UsageFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased;

  Defer<IVerifyIdentified<TUsage, TIdentified>>.D IdentifiedFor<TUsage, TIdentified>([CallerMemberName] string callerName = "")
    where TUsage : IAstError
    where TIdentified : IAstIdentified;

  Defer<IVerifyDomain>.DA GetDomains([CallerMemberName] string callerName = "");

  Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "");

  Defer<IMerge<T>>.D MergerFor<T>([CallerMemberName] string callerName = "")
    where T : IAstError;
}
