using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyDirectiveAliasedTests
  : AliasedVerifierBase<IGqlpSchemaDirective>
{
  internal override GroupedVerifier<IGqlpSchemaDirective> NewGroupedVerifier()
    => new VerifyDirectiveAliased(Definition, Merger, Logger);
}
