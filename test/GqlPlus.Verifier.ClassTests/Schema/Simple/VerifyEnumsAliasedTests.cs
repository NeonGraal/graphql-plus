using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema.Simple;
namespace GqlPlus.Schema.Simple;

[TracePerTest]
public class VerifyEnumsAliasedTests
  : AliasedVerifierBase<IGqlpEnum>
{
  internal override GroupedVerifier<IGqlpEnum> NewGroupedVerifier()
    => new VerifyEnumsAliased(Definition, Merger, Logger);
}
