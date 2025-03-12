using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema.Objects;
namespace GqlPlus.Schema.Objects;

[TracePerTest]
public class VerifyOutputsAliasedTests
  : AliasedVerifierBase<IGqlpOutputObject>
{
  internal override GroupedVerifier<IGqlpOutputObject> NewGroupedVerifier()
    => new VerifyOutputsAliased(Definition, Merger, Logger);
}
