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

    _dual = NFor<IGqlpDualObject>("Dual");
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

  [Fact]
  public void Verify_Dual_WithTypeArg_ReturnsNoErrors()
  {
    Define<IGqlpTypeSpecial>("String");

    IGqlpDualObject other = NFor<IGqlpDualObject>("Other");
    IGqlpTypeParam[] typeParams = NForA<IGqlpTypeParam>("a");
    other.TypeParams.Returns(typeParams);
    IGqlpDualBase parent = NFor<IGqlpDualBase>("a");
    parent.IsTypeParam.Returns(true);
    other.ObjParent.Returns(parent);

    IGqlpDualField field = NFor<IGqlpDualField>("field");
    IGqlpDualBase dualBase = NFor<IGqlpDualBase>("Other");
    IGqlpDualArg[] args = NForA<IGqlpDualArg>("String");
    dualBase.Args.Returns(args);
    dualBase.BaseArgs.Returns(args);
    field.Type.Returns(dualBase);
    field.BaseType.Returns(dualBase);

    _dual.Fields.Returns([field]);
    _dual.ObjFields.Returns([field]);

    Usages.Add(_dual);
    Definitions.Add(other);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
