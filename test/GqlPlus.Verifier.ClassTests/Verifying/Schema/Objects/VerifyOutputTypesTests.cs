using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputTypesTests
  : UsageVerifierBase<IGqlpOutputObject>
{
  private readonly ForM<IGqlpOutputField> _fields = new();
  private readonly ForM<IGqlpOutputAlternate> _mergeAlternates = new();
  private readonly VerifyOutputTypes _verifier;

  private readonly IGqlpOutputObject _output;

  public VerifyOutputTypesTests()
  {
    _verifier = new(Aliased.Intf, _fields.Intf, _mergeAlternates.Intf, Logger);

    _output = NFor<IGqlpOutputObject>("Output");
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
  public void Verify_Output_ReturnsNoErrors()
  {
    Usages.Add(_output);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
