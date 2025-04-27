using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyEnumTypesTests
  : UsageVerifierBase<IGqlpEnum>
{
  private readonly ForM<IGqlpEnumLabel> _mergeLabels = new();
  private readonly VerifyEnumTypes _verifier;

  private readonly IGqlpEnum _enum;

  public VerifyEnumTypesTests()
  {
    _verifier = new(Aliased.Intf, _mergeLabels.Intf);

    _enum = NFor<IGqlpEnum>("Enum");
  }

  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      _mergeLabels.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Enum_ReturnsNoErrors()
  {
    Usages.Add(_enum);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
