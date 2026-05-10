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
  Verifier<T> VerifierFor<T>([CallerMemberName] string callerName = "");

  AliasVerifier<T> AliasedFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased;

  UsageVerifier<T> UsageFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased;

  IdentifiedVerifier<TUsage, TIdentified> IdentifiedFor<TUsage, TIdentified>([CallerMemberName] string callerName = "")
    where TUsage : IAstError
    where TIdentified : IAstIdentified;

  DeferList<IVerifyDomain>.D GetDomains([CallerMemberName] string callerName = "");

  Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "");

  MergerOne<T>.D MergerFor<T>([CallerMemberName] string callerName = "")
    where T : IAstError;
}
