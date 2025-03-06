using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema.Globals;
namespace GqlPlus.Schema.Globals;

[TracePerTest]
public class VerifyOptionAliasedTests
  : AliasedVerifierBase<IGqlpSchemaOption>
{
  internal override GroupedVerifier<IGqlpSchemaOption> NewGroupedVerifier()
    => new VerifyOptionAliased(Definition, Merger, Logger);
}
