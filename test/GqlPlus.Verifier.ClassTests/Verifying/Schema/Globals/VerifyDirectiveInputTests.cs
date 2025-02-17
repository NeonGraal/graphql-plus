using GqlPlus.Abstractions.Schema;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyDirectiveInputTests
  : UsageVerifierBase<IGqlpSchemaDirective>
{
  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    VerifyDirectiveInput verifier = new(Aliased);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.ReceivedWithAnyArgs().Verify(Arg.Any<IGqlpSchemaDirective[]>(), Errors);
    Errors.Should().BeNullOrEmpty();
  }
}
