using GqlPlus.Abstractions.Schema;
using GqlPlus.Schema;
using GqlPlus.Verifying.Schema.Globals;

namespace GqlPlus.Schema.Globals;

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
