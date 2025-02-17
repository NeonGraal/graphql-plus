using GqlPlus.Abstractions.Schema;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyCategoryOutputTests
  : UsageVerifierBase<IGqlpSchemaCategory>
{
  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    VerifyCategoryOutput verifier = new(Aliased);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.ReceivedWithAnyArgs().Verify(Arg.Any<IGqlpSchemaCategory[]>(), Errors);
    Errors.Should().BeNullOrEmpty();
  }
}
