using GqlPlus.Abstractions.Schema;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyCategoryAliasedTests
  : GroupedVerifierBase<IGqlpSchemaCategory>
{
  internal override AliasedVerifier<IGqlpSchemaCategory> NewAliasedVerifier(IVerify<IGqlpSchemaCategory> definition)
    => new VerifyCategoryAliased(definition, Merger, Logger);
}
