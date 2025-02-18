using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyCategoryAliasedTests
  : AliasedVerifierBase<IGqlpSchemaCategory>
{
  internal override GroupedVerifier<IGqlpSchemaCategory> NewGroupedVerifier()
    => new VerifyCategoryAliased(Definition, Merger, Logger);
}
