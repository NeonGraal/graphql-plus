using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyDirectiveInputTests
  : UsageVerifierBase<IGqlpSchemaDirective>
{
  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    VerifyDirectiveInput verifier = new(Aliased.Intf);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.Called();
    Errors.Should().BeNullOrEmpty();
  }
}
