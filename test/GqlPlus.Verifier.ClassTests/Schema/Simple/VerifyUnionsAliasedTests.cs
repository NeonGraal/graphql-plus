using GqlPlus.Abstractions.Schema;
using GqlPlus.Schema;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema.Simple;
namespace GqlPlus.Schema.Simple;

[TracePerTest]
public class VerifyUnionsAliasedTests
  : AliasedVerifierBase<IGqlpUnion>
{
  internal override GroupedVerifier<IGqlpUnion> NewGroupedVerifier()
    => new VerifyUnionsAliased(Definition, Merger, Logger);
}
