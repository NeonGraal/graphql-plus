using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyDirectiveAliasedTests
  : GroupedVerifierBase<IGqlpSchemaDirective>
{
  internal override AliasedVerifier<IGqlpSchemaDirective> NewAliasedVerifier(IVerify<IGqlpSchemaDirective> definition)
    => new VerifyDirectiveAliased(definition, Merger, Logger);
}
