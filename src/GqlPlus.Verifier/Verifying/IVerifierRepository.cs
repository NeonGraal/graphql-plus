using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Verifying;

public interface IVerifierRepository
{
  IVerify<T> VerifierFor<T>();

  IVerifyAliased<T> AliasedFor<T>()
    where T : IGqlpAliased;

  IVerifyUsage<T> UsageFor<T>()
    where T : IGqlpAliased;

  IVerifyIdentified<TUsage, TIdentified> IdentifiedFor<TUsage, TIdentified>()
    where TUsage : IGqlpError
    where TIdentified : IGqlpIdentified;

  IEnumerable<IVerifyDomain> GetDomains();

  ILoggerFactory LoggerFactory { get; }

  IMerge<T> MergeFor<T>()
    where T : IGqlpError;

  IMatcherRepository Matchers { get; }

  IGqlpFieldKind<T> FieldKindFor<T>()
    where T : IGqlpObjField;
}
