using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyOptionAliasedTests
  : AliasedVerifierTestsBase<IGqlpSchemaOption>
{

  [Fact]
  public void Verify_DifferentSchemaNames_ReturnsErrors()
  {
    GroupedVerifier<IGqlpSchemaOption> verifier = NewGroupedVerifier();

    IGqlpSchemaOption[] items = NForA<IGqlpSchemaOption>("Schema", "Name");

    verifier.Verify(items, Errors);

    Errors.ShouldNotBeEmpty();
  }

  internal override GroupedVerifier<IGqlpSchemaOption> NewGroupedVerifier()
    => new VerifyOptionAliased(Definition, Merger, LoggerFactory);
}
