using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema.Globals;
using NSubstitute;

namespace GqlPlus.Schema.Globals;

[TracePerTest]
public class VerifyDirectiveInputTests
  : UsageVerifierBase<IGqlpSchemaDirective>
{
  private readonly VerifyDirectiveInput _verifier;
  private readonly IGqlpSchemaDirective _directive;

  public VerifyDirectiveInputTests()
  {
    _verifier = new(Aliased.Intf);

    IGqlpInputParam input = EFor<IGqlpInputParam>();
    IGqlpInputBase type = NFor<IGqlpInputBase>("Type");
    input.Type.Returns(type);

    _directive = EFor<IGqlpSchemaDirective>();
    _directive.Params.Returns([input]);
  }

  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_UndefinedInput_ReturnsError()
  {
    Usages.Add(_directive);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_DefinedInput_ReturnsNoError()
  {
    Definitions.Add(NFor<IGqlpInputObject>("Type"));

    Usages.Add(_directive);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_DefinedOutput_ReturnsError()
  {
    Definitions.Add(NFor<IGqlpOutputObject>("Type"));

    Usages.Add(_directive);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
