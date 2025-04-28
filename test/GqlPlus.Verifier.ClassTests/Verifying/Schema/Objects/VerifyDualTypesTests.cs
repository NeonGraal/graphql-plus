using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualTypesTests
  : UsageVerifierBase<IGqlpDualObject>
{
  private readonly ForM<IGqlpDualField> _fields = new();
  private readonly ForM<IGqlpDualAlternate> _mergeAlternates = new();
  private readonly VerifyDualTypes _verifier;

  private readonly IGqlpDualObject _dual;

  public VerifyDualTypesTests()
  {
    _verifier = new(Aliased.Intf, _fields.Intf, _mergeAlternates.Intf, Logger);

    _dual = For<IGqlpDualObject>();
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
  public void Verify_Dual_ReturnsNoErrors()
  {
    Usages.Add(_dual);
    Definitions.Add(_dual);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Dual_WithTypeParams_ReturnsNoErrors()
  {
    IGqlpTypeParam[] typeParams = NForA<IGqlpTypeParam>("a");
    _dual.TypeParams.Returns(typeParams);
    IGqlpDualBase parent = NFor<IGqlpDualBase>("a");
    parent.IsTypeParam.Returns(true);
    _dual.ObjParent.Returns(parent);

    Usages.Add(_dual);
    Definitions.Add(_dual);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
