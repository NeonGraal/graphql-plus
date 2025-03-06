using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema.Globals;

namespace GqlPlus.Schema.Globals;

[TracePerTest]
public class VerifyCategoryAliasedTests
  : AliasedVerifierBase<IGqlpSchemaCategory>
{
  internal override GroupedVerifier<IGqlpSchemaCategory> NewGroupedVerifier()
    => new VerifyCategoryAliased(Definition, Merger, Logger);
}
