using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputsAliasedTests
  : AliasedVerifierBase<IGqlpOutputObject>
{
  internal override GroupedVerifier<IGqlpOutputObject> NewGroupedVerifier()
    => new VerifyOutputsAliased(Definition, Merger, Logger);
}
