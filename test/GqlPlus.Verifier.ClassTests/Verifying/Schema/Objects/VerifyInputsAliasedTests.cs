using GqlPlus.Verification.Schema;
namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputsAliasedTests
  : AliasedVerifierTestsBase<IGqlpInputObject>
{
  internal override GroupedVerifier<IGqlpInputObject> NewGroupedVerifier()
    => new VerifyInputsAliased(Definition, Merger, LoggerFactory);
}
