using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema;
namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyUnionsAliasedTests
  : AliasedVerifierBase<IGqlpUnion>
{
  internal override GroupedVerifier<IGqlpUnion> NewGroupedVerifier()
    => new VerifyUnionsAliased(Definition, Merger, Logger);
}
