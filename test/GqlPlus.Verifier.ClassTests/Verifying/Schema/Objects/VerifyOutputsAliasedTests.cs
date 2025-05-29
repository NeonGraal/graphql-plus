using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputsAliasedTests
  : AliasedVerifierTestsBase<IGqlpOutputObject>
{
  internal override GroupedVerifier<IGqlpOutputObject> NewGroupedVerifier()
    => new VerifyOutputsAliased(Definition, Merger, LoggerFactory);
}
