using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyOptionAliasedTests
  : GroupedVerifierBase<IGqlpSchemaOption>
{
  internal override AliasedVerifier<IGqlpSchemaOption> NewAliasedVerifier(IVerify<IGqlpSchemaOption> definition)
    => new VerifyOptionAliased(definition, Merger, Logger);
}
