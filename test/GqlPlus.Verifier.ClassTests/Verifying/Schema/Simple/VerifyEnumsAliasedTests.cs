using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyEnumsAliasedTests
  : AliasedVerifierTestsBase<IGqlpEnum>
{
  internal override GroupedVerifier<IGqlpEnum> NewGroupedVerifier()
    => new VerifyEnumsAliased(Definition, Merger, LoggerFactory);
}
