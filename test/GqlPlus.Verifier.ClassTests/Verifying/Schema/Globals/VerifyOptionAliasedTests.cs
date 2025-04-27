using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema;
namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyOptionAliasedTests
  : AliasedVerifierBase<IGqlpSchemaOption>
{

  [Fact]
  public void Verify_DifferentSchemaNames_ReturnsErrors()
  {
    GroupedVerifier<IGqlpSchemaOption> verifier = NewGroupedVerifier();

    IGqlpSchemaOption[] items = [NFor<IGqlpSchemaOption>("Schema"), NFor<IGqlpSchemaOption>("Name")];

    verifier.Verify(items, Errors);

    Errors.ShouldNotBeEmpty();
  }

  internal override GroupedVerifier<IGqlpSchemaOption> NewGroupedVerifier()
    => new VerifyOptionAliased(Definition, Merger, Logger);
}
