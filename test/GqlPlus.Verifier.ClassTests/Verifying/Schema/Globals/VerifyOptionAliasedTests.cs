using GqlPlus.Abstractions.Schema;

using GqlPlus.Verification.Schema;
namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyOptionAliasedTests
  : AliasedVerifierBase<IGqlpSchemaOption>
{
  internal override GroupedVerifier<IGqlpSchemaOption> NewGroupedVerifier()
    => new VerifyOptionAliased(Definition, Merger, Logger);
}
