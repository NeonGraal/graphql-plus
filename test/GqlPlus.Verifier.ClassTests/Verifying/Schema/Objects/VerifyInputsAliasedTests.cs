using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema;
namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputsAliasedTests
  : AliasedVerifierBase<IGqlpInputObject>
{
  internal override GroupedVerifier<IGqlpInputObject> NewGroupedVerifier()
    => new VerifyInputsAliased(Definition, Merger, Logger);
}
