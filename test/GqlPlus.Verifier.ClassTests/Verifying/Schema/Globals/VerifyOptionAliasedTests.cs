using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyOptionAliasedTests
  : AliasedVerifierTestsBase<IAstSchemaOption>
{

  [Fact]
  public void Verify_DifferentSchemaNames_ReturnsErrors()
  {
    GroupedVerifier<IAstSchemaOption> verifier = NewGroupedVerifier();

    IAstSchemaOption[] items = A.NamedArray<IAstSchemaOption>("Schema", "Name");

    verifier.Verify(items, Errors);

    Errors.ShouldNotBeEmpty();
  }

  internal override GroupedVerifier<IAstSchemaOption> NewGroupedVerifier()
    => new VerifyOptionAliased(VerifierRepo);
}
