using GqlPlus.Abstractions.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualTypes(
  ObjectVerifierParams<IGqlpDualObject, IGqlpDualField, IGqlpDualAlternate> verifiers
) : AstObjectVerifier<IGqlpDualObject, IGqlpDualBase, IGqlpDualArg, IGqlpDualField, IGqlpDualAlternate, UsageContext>(verifiers)
{
  protected override UsageContext MakeContext(IGqlpDualObject usage, IGqlpType[] aliased, ITokenMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParams.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors);
  }
}
