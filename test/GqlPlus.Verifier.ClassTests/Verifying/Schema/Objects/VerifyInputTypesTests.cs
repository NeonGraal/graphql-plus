using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputTypesTests
  : UsageVerifierBase<IGqlpInputObject>
{
  private readonly ForM<IGqlpInputField> _fields = new();
  private readonly ForM<IGqlpInputAlternate> _mergeAlternates = new();
  private readonly VerifyInputTypes _verifier;

  private readonly IGqlpInputObject _input;

  public VerifyInputTypesTests()
  {
    _verifier = new(Aliased.Intf, _fields.Intf, _mergeAlternates.Intf, Logger);

    _input = NFor<IGqlpInputObject>("Input");
  }

  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      _fields.NotCalled,
      _mergeAlternates.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Input_ReturnsNoErrors()
  {
    Usages.Add(_input);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
