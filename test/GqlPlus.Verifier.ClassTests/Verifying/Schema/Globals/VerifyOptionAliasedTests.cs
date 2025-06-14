namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyOptionAliasedTests
  : AliasedVerifierTestsBase<IGqlpSchemaOption>
{

  [Fact]
  public void Verify_DifferentSchemaNames_ReturnsErrors()
  {
    GroupedVerifier<IGqlpSchemaOption> verifier = NewGroupedVerifier();

    IGqlpSchemaOption[] items = A.NamedArray<IGqlpSchemaOption>("Schema", "Name");

    verifier.Verify(items, Errors);

    Errors.ShouldNotBeEmpty();
  }

  internal override GroupedVerifier<IGqlpSchemaOption> NewGroupedVerifier()
    => new VerifyOptionAliased(Definition, Merger, LoggerFactory);
}
